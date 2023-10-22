using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject ShoppingPanel;
    private void OnMouseDown()
    {
        ShoppingPanel.SetActive(true);
    }


}

