using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Tooltip("Prefabs that have a Pickup component on the root.")]
    public List<GameObject> itemPrefabs = new List<GameObject>();

    public Vector2 areaMin = new Vector2(-10, -10);
    public Vector2 areaMax = new Vector2(10, 10);

    public float spawnInterval = 2f;
    public int maxItems = 20;

    private readonly List<GameObject> _spawned = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            if (_spawned.Count < maxItems)
                SpawnItem();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnItem()
    {
        if (itemPrefabs.Count == 0) return;

        var prefab = itemPrefabs[Random.Range(0, itemPrefabs.Count)];
        Vector3 pos = new Vector3(Random.Range(areaMin.x, areaMax.x), Random.Range(areaMin.y, areaMax.y), 0f);
        var instance = Instantiate(prefab, pos, Quaternion.identity);
        _spawned.Add(instance);

        instance.transform.SetParent(transform);

        // Clean up list from destroyed
        _spawned.RemoveAll(item => item == null);
    }
}