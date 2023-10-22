using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShoppingController : MonoBehaviour
{
    [SerializeField] private MainCharacter character;

    [Header("Hat Section")]
    [SerializeField] private Image hatSprite;
    [SerializeField] private Image hatIcon;
    [SerializeField] private Animator hatAnimator;

    [Header("Clothing Section")]
    [SerializeField] private Image clothingSprite;
    [SerializeField] private Image clothingIcon;
    [SerializeField] private Animator clothingAnimator;

    [Header("Button Section")]
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private Button closeButton;

    [Header("Money Section")]
    [SerializeField] private TextMeshProUGUI shoppingCartValue;
    [SerializeField] private TextMeshProUGUI playerCoinText;
    [SerializeField] private TextMeshProUGUI ownedOutiftValueText;

    private Item newHat;
    private Item newClothing;

    private int totalValue;
    private int ownedOutiftValue;
    private int playerCoin = 9000;
    private Button lastSelectedHat;
    private Button lastSelectedClothing;


    private void OnEnable()
    {
        buyButton.onClick.AddListener(BuyItens);
        sellButton.onClick.AddListener(SellItens);
    }

    private void Update()
    {
        buyButton.interactable = totalValue > 0;
        sellButton.interactable = ownedOutiftValue > 0;
    }
    public void TryOutfit(Item item, Button itemButton)
    {
        switch (item.Type)
        {
            case Item.ItemType.Hat:
                SetSelectedItem(ref lastSelectedHat, item, itemButton, hatSprite, hatIcon);
                newHat = item;
                break;

            case Item.ItemType.Clothing:
                SetSelectedItem(ref lastSelectedClothing, item, itemButton, clothingSprite, clothingIcon);
                newClothing = item;
                break;
        }

        int newHatValue = (newHat != null) ? newHat.ItemValue : 0;
        int newClothingValue = (newClothing != null) ? newClothing.ItemValue : 0;

        totalValue = newClothingValue + newHatValue;
        shoppingCartValue.text = totalValue.ToString();
    }
    private void SetSelectedItem(ref Button lastSelected, Item item, Button itemButton, Image sprite, Image icon)
    {
        if (lastSelected != null)
        {
            lastSelected.interactable = true;
        }

        sprite.enabled = true;
        icon.enabled = true;

        lastSelected = itemButton;
        sprite.sprite = item.CharItem;
        icon.sprite = item.Icon;
        itemButton.interactable = false;
    }
    private void BuyItens()
    {
        if (newHat != null)
            hatAnimator.runtimeAnimatorController = newHat.AnimatorController;

        if (newClothing != null)
            clothingAnimator.runtimeAnimatorController = newClothing.AnimatorController;

        playerCoin -= totalValue;
        ownedOutiftValue = totalValue;

        totalValue = 0;

        playerCoinText.text = playerCoin.ToString();
        shoppingCartValue.text = totalValue.ToString();
        ownedOutiftValueText.text = ownedOutiftValue.ToString();

    }

    private void SellItens()
    {
        ResetOutfit();

        lastSelectedHat.interactable = true;
        lastSelectedClothing.interactable = true;

        hatAnimator.runtimeAnimatorController = null;
        clothingAnimator.runtimeAnimatorController = null;

        playerCoin += ownedOutiftValue;
        playerCoinText.text = playerCoin.ToString();

        ownedOutiftValue = 0;
        ownedOutiftValueText.text = ownedOutiftValue.ToString();
    }

    private void ResetOutfit()
    {
        hatSprite.enabled = false;
        hatIcon.enabled = false;
        clothingSprite.enabled = false;
        clothingIcon.enabled = false;

    }
}
