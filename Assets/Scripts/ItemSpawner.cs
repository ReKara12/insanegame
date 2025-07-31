using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public List<GameObject> itemPrefabs = new List<GameObject>();
    public Vector2 areaMin = new Vector2(-10, -10);
    public Vector2 areaMax = new Vector2(10, 10);
    public int initialSpawnCount = 10;

    private void Start()
    {
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        if (itemPrefabs.Count == 0) return;

        var prefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        Vector3 pos = new Vector3(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y), 0f);
        Instantiate(prefab, pos, Quaternion.identity, transform);
    }
}
