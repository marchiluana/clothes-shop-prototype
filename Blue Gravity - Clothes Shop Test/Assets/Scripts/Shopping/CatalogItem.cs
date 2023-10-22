using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatalogItem : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI valueText;
    public void Setup(Item itemData)
    {
        icon.sprite = itemData.Icon;
        nameText.text = itemData.ItemName;
        valueText.text = itemData.ItemValue.ToString();
    }
}