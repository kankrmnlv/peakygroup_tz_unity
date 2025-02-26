using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class ItemsUI : MonoBehaviour
{
    public static ItemsUI Instance;

    public GameObject itemPanel;
    public TMP_Text itemList;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateItems(ItemSaver.Instance.GetRecentItems());
    }

    public void UpdateItems(List<string> items)
    {
        itemList.text = string.Join("\n", items.AsEnumerable().Reverse());
    }

    public void ToggleItemsScreen()
    {
        itemPanel.SetActive(!itemPanel.activeSelf);
        if(itemPanel.activeSelf)
        {
            UpdateItems(ItemSaver.Instance.GetRecentItems());
        }
    }
}
