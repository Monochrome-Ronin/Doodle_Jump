using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Environments[] _platforms;
    [SerializeField] private Transform _topBound;
    [SerializeField] private GameObject _coin;
    Environments _lastPlatform;
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
        spawnPostion.y = Random.Range(0.5f, 2.5f) ;
        if (_lastPlatform != null)
            spawnPostion.y += _lastPlatform.transform.position.y;
        else
        {
            spawnPostion.y = -3.5f;
            spawnPostion.x = 0;
        }

        _lastPlatform = Instantiate(_platforms[Random.Range(0, _platforms.Length)], spawnPostion, Quaternion.identity);
        
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
    
}
