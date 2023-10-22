using UnityEngine;
using UnityEngine.UI;

public class FittingRoom : MonoBehaviour
{
    [SerializeField] private MainCharacter character;

    [Header("Hat Section")]
    [SerializeField] private Image hatSprite;
    [SerializeField] private Animator hatAnimator;

    [Header("Clothing Section")]
    [SerializeField] private Image clothingSprite;
    [SerializeField] private Animator clothingAnimator;


    [Header("Button Section")]
    [SerializeField] private Button buyButton;

    private Item newHat;
    private Item newClothing;
    private void OnEnable()
    {
        buyButton.onClick.AddListener(BuyItens);
    }
    public void TryOutfit(Item item)
    {
        switch (item.Type)
        {
            case Item.ItemType.Hat:
                newHat = item;
                hatSprite.sprite = item.CharItem;
                break;

            case Item.ItemType.Clothing:
                newClothing = item;
                clothingSprite.sprite = item.CharItem;
                break;
        }
    }
    private void BuyItens()
    {
        if (newHat != null)
            hatAnimator.runtimeAnimatorController = newHat.AnimatorController;

        if (newClothing != null)
            clothingAnimator.runtimeAnimatorController = newClothing.AnimatorController;

    }
}
