using UnityEngine;

public class MainCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Animator animator;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movement = new Vector2(horizontalInput, verticalInput).normalized;

        string animationTrigger = GetAnimationTrigger(horizontalInput, verticalInput);

        rb.velocity = movement * moveSpeed;

        animator.SetTrigger(animationTrigger);
    }

    string GetAnimationTrigger(float horizontalInput, float verticalInput)
    {
        return (horizontalInput > 0) ? "Right" :
           (horizontalInput < 0) ? "Left" :
           (verticalInput > 0) ? "Up" :
           (verticalInput < 0) ? "Down" :
           "Idle";
    }
}

