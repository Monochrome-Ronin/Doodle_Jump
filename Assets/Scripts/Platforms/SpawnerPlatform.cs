using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{
    [SerializeField] private BasePlatform[] _platforms;
    private void Start()
    {
        Vector3 spawnPostion = new Vector3();
        for (int i = 0; i < 10; i++)
        {
            spawnPostion.x = Random.Range(-2, 2);
            if (i != 0) spawnPostion.y += Random.Range(0.5f, 2.5f);
            else spawnPostion.y = -1.5f;
            Instantiate(_platforms[Random.Range(0, _platforms.Length)], spawnPostion, Quaternion.identity);
        }
    }
}
