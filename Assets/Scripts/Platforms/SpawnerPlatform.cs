using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{
    [SerializeField] private BasePlatform[] _platforms;
    [SerializeField] private Transform _topBound;
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
        spawnPostion.y = Random.Range(0.5f, 2.5f) ;
        if (_lastPlatform != null)
            spawnPostion.y += _lastPlatform.transform.position.y;
        else
        {
            spawnPostion.y = -3.5f;
            spawnPostion.x = 0;
        }

        _lastPlatform = Instantiate(_platforms[Random.Range(0, _platforms.Length)], spawnPostion, Quaternion.identity);
    }
}
