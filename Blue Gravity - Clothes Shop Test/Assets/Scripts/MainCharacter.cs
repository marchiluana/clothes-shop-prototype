using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    #region variables
    [Header("Character Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movement;

    [Header("Character Animation")]
    [SerializeField] private Animator[] animators;

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
    #endregion

    #region private methods

    private void Update()
    {
        CharacterMovement();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
    }

    private void CharacterMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        movement = new Vector2(horizontalInput, verticalInput);

        foreach (Animator anim in animators)
        {
            if (movement != Vector2.zero)
            {
                anim.SetTrigger("Moving");
                anim.SetFloat("Horizontal", movement.x);
                anim.SetFloat("Vertical", movement.y);
            }
            else
            {
                anim.SetTrigger("Idle");
            }
        }

    }
    #endregion

}

