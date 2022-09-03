using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int[] _chanceOfEnviroments;
    [SerializeField] private Environments[] _environments;
    [SerializeField] private Transform _topBound;
    [SerializeField] Environments _lastPlatform;
    private void FixedUpdate()
    {
        if (_lastPlatform.transform.position.y < _topBound.position.y)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        Vector3 spawnPostion = new Vector3();
        spawnPostion.x = Random.Range(-2, 2);
        spawnPostion.y = Random.Range(0.5f, 1.3f) ;
        if (_lastPlatform != null)
            spawnPostion.y += _lastPlatform.transform.position.y;
        else
        {
            spawnPostion.y = -3.5f;
            spawnPostion.x = 0;
        }

        _lastPlatform = Instantiate(RandomSpawn(), spawnPostion, Quaternion.identity);
        
        
    }

   /*private void SpawnCoin()
    {
        int _randomNumber = Random.Range(0, 10);
        if (_randomNumber > 6)
        {
            CollectCoin coin = Instantiate(_coin,
                new Vector3(_lastPlatform.transform.position.x + Random.Range(-1, 1),
                    _lastPlatform.transform.position.y + Random.Range(1f, 2.5f), 0), _coin.transform.rotation, transform);
            

        }
    }*/

    Environments RandomSpawn()
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
}
