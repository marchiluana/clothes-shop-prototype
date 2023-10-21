using UnityEngine;

public class ClothShopping : MonoBehaviour
{
    [SerializeField] private GameObject ShoppingPanel;
    private void OnMouseDown()
    {
        ShoppingPanel.SetActive(true);
    }


}

