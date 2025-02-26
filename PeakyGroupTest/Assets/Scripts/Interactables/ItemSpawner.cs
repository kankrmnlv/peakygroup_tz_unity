using Unity.VisualScripting;
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

        InvokeRepeating(nameof(SpawnItem), 5f, spawnInterval);
    }
    private void SpawnItem()
    {
        if(GameObject.FindGameObjectsWithTag("Interactable").Length >= maxItems)
        {
            return;
        }

        Vector3 randomSpawnPos = Vector3.zero;
        bool foundGoodPos = false;

        for(int i = 0; i < 10; i++)
        {
            randomSpawnPos = new Vector3(Random.Range(-spawnArea / 2f, spawnArea / 2f), 1f, Random.Range(-spawnArea / 2f, spawnArea / 2f));
            if (IsSpawnPositionGood(randomSpawnPos))
            {
                foundGoodPos = true;
                break;
            }
        }

        if (foundGoodPos)
        {
            GameObject itemPrefab = items[Random.Range(0, items.Length)];
            Instantiate(itemPrefab, randomSpawnPos, Quaternion.identity);
        }
    }

    private bool IsSpawnPositionGood(Vector3 position, float radius = 2f)
    {
        Collider[] colliders = Physics.OverlapSphere(position, radius);

        foreach(Collider collider in colliders)
        {
            if(collider.CompareTag("Interactable") || collider.CompareTag("Player"))
            {
                return false;
            }
        }

        return true;
    }
}
