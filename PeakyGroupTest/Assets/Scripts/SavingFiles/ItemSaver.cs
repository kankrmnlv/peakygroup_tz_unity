using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;

public class ItemSaver : MonoBehaviour
{
    public static ItemSaver Instance;

    public int maxItemsToShow = 10;

    private string filePath;
    private List<string> items = new List<string>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        filePath = Path.Combine(Application.persistentDataPath, "items.txt");
        LoadItems();
    }
    public void ItemPickup(string itemName)
    {
        string itemEntry = $"Picked {itemName} at {DateTime.Now:HH:mm}";
        items.Add(itemEntry);

        File.AppendAllLines(filePath, new string[] {itemEntry});

        if(ItemsUI.Instance != null)
        {
            ItemsUI.Instance.UpdateItems(GetRecentItems());
        }
    }

    private void LoadItems()
    {
        if (File.Exists(filePath))
        {
            items = new List<string>(File.ReadAllLines(filePath));
        }
    }

    public List<string> GetRecentItems()
    {
        int startIndex = Mathf.Max(0, items.Count - maxItemsToShow);
        return items.GetRange(startIndex, Math.Min(maxItemsToShow, items.Count));
    }

    public List<string> GetItems()
    {
        return items;
    }
}
