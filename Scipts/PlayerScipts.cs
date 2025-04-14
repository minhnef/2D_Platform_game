using UnityEngine;

public class PlayerScipts : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform GroundCheck;

    private Animator animator;
    private bool isGrounded;


    private Rigidbody2D rb;

    private GameManager gameManager;
    private AudioManager audioManager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponent<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver() || gameManager.isGameWin()) return;
        handleMovement();
        handleJump();
        updateAnimator();
    }


    private void handleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2 (moveInput*moveSpeed, rb.linearVelocityY);
        if (moveInput > 0) transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }


    private void handleJump()
    {
        if (Input.GetButtonDown("Jump")&&isGrounded)
        {
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioManager.playJumpSound();
        }
        isGrounded=Physics2D.OverlapCircle(GroundCheck.position, 0.2f, groundLayer);
    }

    private void updateAnimator()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        bool isJumping = !isGrounded;
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isjumping", isJumping);
    }
}//do not delete this
