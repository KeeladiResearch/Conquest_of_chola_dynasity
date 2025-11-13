using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CharacterController2D : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("Grounded", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGrounded = false;
    }
}
