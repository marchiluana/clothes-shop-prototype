using UnityEngine;
using UnityEngine.UI;

public class Catalog : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Transform catalogGrid;
    [SerializeField] private Item[] items;
    [SerializeField] private FittingRoom fittingRoom;

    private void Start()
    {
        foreach (Item itemData in items)
        {
            GameObject newItem = Instantiate(itemPrefab, catalogGrid);

            CatalogItem catalogItem = newItem.GetComponent<CatalogItem>();
            Button button = newItem.GetComponent<Button>();

            catalogItem.Setup(itemData);

            button.onClick.AddListener(() => fittingRoom.TryOutfit(itemData));
        }
    }
}
