using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int[] _chanceOfEnviroments;
    [SerializeField] private Environments[] _environments;
    [SerializeField] private int[] _chanceOfBoosts;
    [SerializeField] private Boost[] _boosts;
    [SerializeField] private int _chanceOfSpawnBoost = 2;
    [SerializeField] private Transform _topBound;
    [SerializeField] Environments _lastPlatform;
    private void FixedUpdate()
    {
        if (_lastPlatform.transform.position.y < _topBound.position.y)
        {
            SpawnPlatform();
            SpawnBoost();
        }
    }

    private void SpawnPlatform()
    {
        Vector3 spawnPostion = new Vector3();
        spawnPostion.y = Random.Range(0.5f, 1.3f);
        do
        {
            spawnPostion.x = Random.Range(-2, 2);
        }
        while (Mathf.Abs(spawnPostion.x - _lastPlatform.transform.position.x) < .2f);
        if (_lastPlatform != null)
            spawnPostion.y += _lastPlatform.transform.position.y;
        else
        {
            spawnPostion.y = -3.5f;
            spawnPostion.x = 0;
        }

        _lastPlatform = Instantiate(RandomSpawnPlatform(), spawnPostion, Quaternion.identity);
        
        
    }

    private void SpawnBoost()
    {
        if(Random.Range(0, _chanceOfSpawnBoost) == 1)
        {
            Vector3 offset = new Vector3();
            Boost boost = RandomSpawnBoost();
            if(boost.CompareTag("Spring"))
                offset = new Vector3(0, .2f);
            else if(boost.CompareTag("Coin"))
                offset = new Vector3(0, .5f);
            if (_lastPlatform.transform.GetComponent<SpriteRenderer>().sprite.name == "Gametiles_0")
            {
                Instantiate(boost, _lastPlatform.transform.position + offset + new Vector3(Random.Range(-0.25f, 0.25f), 0, 0), Quaternion.identity);
            }
        }
    }

    Environments RandomSpawnPlatform()
    {
        int maxValue = 0;
        int currentPlatform = 0;
        int[] randomArr = new int[_environments.Length];
        for (int i = 0; i < _environments.Length; i++)
        {
            randomArr[i] = Random.Range(0, _chanceOfEnviroments[i] + 1);
            if (maxValue < randomArr[i])
            {
                maxValue = randomArr[i];
                currentPlatform = i;
            }
        }
        return _environments[currentPlatform];
    }

    Boost RandomSpawnBoost()
    {
        int maxValue = 0;
        int currentBoost = 0;
        int[] randomArr = new int[_boosts.Length];
        for (int i = 0; i < _boosts.Length; i++)
        {
            randomArr[i] = Random.Range(0, _chanceOfBoosts[i] + 1);
            if (maxValue < randomArr[i])
            {
                maxValue = randomArr[i];
                currentBoost = i;
            }
        }
        return _boosts[currentBoost];
    }
}
