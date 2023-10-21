using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    #region variables
    [Header("Character Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Character Acessories")]
    [SerializeField] private SpriteRenderer hatSprite;
    [SerializeField] private SpriteRenderer clothingSprite;

    #endregion

    #region properties

    public Sprite HatSprite
    {
        get { return hatSprite.sprite; }
        set { hatSprite.sprite = value; }
    }

    public Sprite ClothingSprite
    {
        get { return clothingSprite.sprite; }
        set { clothingSprite.sprite = value; }
    }

    #endregion

    #region public methods
    public void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;

    }

    #endregion

}

