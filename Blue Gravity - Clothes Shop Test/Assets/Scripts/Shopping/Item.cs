using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Item/New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private Sprite charItem;
    [SerializeField] private Sprite icon;
    [SerializeField] private string itemName;
    [SerializeField] private string itemValue;
    [SerializeField] private RuntimeAnimatorController animatorController;
    [SerializeField] private ItemType itemType;

    public Sprite Icon { get { return icon; } }
    public string ItemName { get { return itemName; } }
    public string ItemValue { get { return itemValue; } }
    public Sprite CharItem { get { return charItem; } }
    public RuntimeAnimatorController AnimatorController { get { return animatorController; } }
    public ItemType Type { get { return itemType; } }

    public enum ItemType
    {
        Clothing,
        Hat
    }

}
