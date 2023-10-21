using UnityEngine;

public class Cloth_Shopping : MonoBehaviour
{
    [SerializeField] private GameObject ShoppingPanel;
    private void OnMouseDown()
    {
        ShoppingPanel.SetActive(true);
    }


}

