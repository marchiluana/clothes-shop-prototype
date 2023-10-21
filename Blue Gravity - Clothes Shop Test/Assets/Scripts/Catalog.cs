using UnityEngine;

public class Catalog : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform catalogGrid;
    public Item[] items;

    private void Start()
    {
        foreach (Item itemData in items)
        {
            GameObject newItem = Instantiate(itemPrefab, catalogGrid);

            CatalogItem catalogItem = newItem.GetComponent<CatalogItem>();

            catalogItem.Setup(itemData);
        }
    }
}
