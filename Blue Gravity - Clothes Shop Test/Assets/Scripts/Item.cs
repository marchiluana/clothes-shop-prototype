using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite charItem;
    [SerializeField] private Sprite icon;
    [SerializeField] private string itemName;
    [SerializeField] private string itemValue;

    public Sprite Icon
    {
        get { return icon; }
    }

    public string ItemName
    {
        get { return itemName; }
    }

    public string ItemValue
    {
        get { return itemValue; }
    }

    public Sprite CharItem
    {
        get { return charItem; }
    }


}
