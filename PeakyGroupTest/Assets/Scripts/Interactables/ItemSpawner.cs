using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;

    public GameObject[] items;
    public int maxItems;
    public float spawnInterval;
    
    private float spawnArea = 20f;

    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InvokeRepeating("SpawnItem", 0f, spawnInterval);
    }
    private void SpawnItem()
    {
        if(GameObject.FindGameObjectsWithTag("Interactable").Length >= maxItems)
        {
            return;
        }

        Vector3 randomSpawnPos = new Vector3(Random.Range(-spawnArea / 2f, spawnArea / 2f), 1f, Random.Range(-spawnArea / 2f, spawnArea / 2f));

        GameObject itemPrefab = items[Random.Range(0, items.Length)];
        Instantiate(itemPrefab, randomSpawnPos, Quaternion.identity);
    }
}
