using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoints;
    [SerializeField]
    private GameObject blockPrefab;
    private float _timeToSpawn = 2f;

    public float _spawnRate;

    void Update()
    {
        if (Time.time >= _timeToSpawn)
        {
            SpawnBlocks();
            _timeToSpawn = Time.time + _spawnRate;
        }

    }

    void SpawnBlocks()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
