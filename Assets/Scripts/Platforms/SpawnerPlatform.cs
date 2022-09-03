using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{
    [SerializeField] private BasePlatform[] _platforms;
    [SerializeField] private int[] _chanceOfPlatrofm;
    [SerializeField] private Transform _topBound;
    [SerializeField] private GameObject _coin;
    BasePlatform _lastPlatform;
    private void FixedUpdate()
    {
        if (_lastPlatform == null)
        {
            SpawnPlatform();
        }
        else if (_lastPlatform.transform.position.y < _topBound.position.y)
        {
            SpawnPlatform();
        }
        
    }

    void SpawnPlatform()
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

        _lastPlatform = Instantiate(RandomPlatform(), spawnPostion, Quaternion.identity);
        
        
    }

    void SpawnCoin()
    {
        int _randomNumber = Random.Range(0, 10);
        if (_randomNumber > 6)
        {
            Instantiate(_coin,
                new Vector3(_lastPlatform.transform.position.x + Random.Range(-1, 1),
                    _lastPlatform.transform.position.y + Random.Range(1f, 2.5f), 0), _coin.transform.rotation, transform);
            if (_coin.transform.position.x < -3f)
            {
                _coin.transform.position = new Vector3(-2.5f, _coin.transform.position.y, 0);
            }
            else if (_coin.transform.position.x > 3f)
            {
                _coin.transform.position = new Vector3(2.5f, _coin.transform.position.y, 0);
            }

        }
    }

    BasePlatform RandomPlatform()
    {
        int maxValue = 0;
        int currentPlatform = 0;
        int[] randomArr = new int[_platforms.Length];
        for (int i = 0; i < _platforms.Length; i++)
        {
            randomArr[i] = Random.Range(0, _chanceOfPlatrofm[i] + 1);
            if (maxValue < randomArr[i])
            {
                maxValue = randomArr[i];
                currentPlatform = i;
            }
        }
        return _platforms[currentPlatform];
    }
}
