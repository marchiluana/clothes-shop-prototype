using UnityEngine;
using UnityEngine.UI;

public class FittingRoom : MonoBehaviour
{
    [SerializeField] private Image clothingSprite;
    [SerializeField] private Image hatSprite;
    [SerializeField] private Button buyButton;
    [SerializeField] private MainCharacter character;

    private void OnEnable()
    {
        buyButton.onClick.AddListener(BuyItens);
    }
    public void TryOutfit(Item item)
    {
        switch (item.Type)
        {
            case Item.ItemType.Clothing:
                clothingSprite.sprite = item.CharItem;
                break;
            case Item.ItemType.Hat:
                hatSprite.sprite = item.CharItem;
                break;
        }
    }
    private void BuyItens()
    {
        character.HatSprite = hatSprite.sprite;
        character.ClothingSprite = clothingSprite.sprite;
    }
}
