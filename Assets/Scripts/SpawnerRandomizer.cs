using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandomizer : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 2f;
    [SerializeField] private List<Spawner> _spawners;

    private void Start()
    {
        InvokeRepeating(nameof(RandomSpawn), 0.0f, _repeatRate);
    }

    public void RandomSpawn()
    {
        Spawner enemySpawner = GetRandomSpawner();
        enemySpawner.Spawn();
    }

    private Spawner GetRandomSpawner()
    {
        int randomSpawnerIndex = Random.Range(0, _spawners.Count);
        return _spawners[randomSpawnerIndex];
    }
}
