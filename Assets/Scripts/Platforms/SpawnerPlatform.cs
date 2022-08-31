using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{
    [SerializeField] private BasePlatform[] _platforms;
    BasePlatform _lastPlatform;
    private void FixedUpdate()
    {
        SpawnPlatform();
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
