using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    //Instance
    private static PlayerControl instance;

    public static PlayerControl Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<PlayerControl>();
            return instance;
        }
    }

    //Game cycle
    public bool Alive { get; set; }
    private bool respawning = false;
    private readonly float timeAfterDeath = 3f;

    //Prefabs
    [SerializeField] private Transform deathPrefab;

    //Audio
    private AudioSource audioSrc;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip deathSound;

    //Spawn
    [SerializeField] private Transform spawnPoint;

    //Animations
    private Animator animator;

    //Movement
    private Rigidbody2D rb;
    private bool facingRight;
    private float dirX;
    private readonly int moveSpeed = 6;
    private readonly int jumpForce = 14;

    //Ground Check
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundPoint;
    private readonly float radius = 0.25f;
    private bool isGrounded = true; 

    //Gravity
    private readonly int fallMultiplier = 6;
    private readonly int lowJumpMultiplier = 5;

    private void Awake()
    {
        facingRight = true;
    }

    private void Start()
    {
        Alive = true;
        audioSrc = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        transform.position = spawnPoint.position;
    }

    private void FixedUpdate()
    {
        if (Alive)
        {
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, whatIsGround);
            HandleMovement();

            if (rb.velocity.y < 0)
                rb.gravityScale = fallMultiplier;
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
                rb.gravityScale = lowJumpMultiplier;
            else
                rb.gravityScale = 2.5f;
        }
    }

    private void Update()
    {
        HandleBoundary();

        if (Alive)
        {
            HandleInput();
            HandleAnimations();
            HandleLayers();
            Flip();
        }
        
        if (!Alive && !respawning)
            StartCoroutine(Death());
        
    }

    private void HandleInput()
    {
        dirX = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void HandleAnimations()
    {
        if (isGrounded)
        {
            animator.SetBool("Falling", false);
            animator.SetFloat("Speed", Mathf.Abs(dirX));
        }

        if (rb.velocity.y < 0 && !isGrounded)
        {
            animator.SetBool("Falling", true);
        }
            

    }

    private void HandleMovement()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    private void HandleLayers()
    {
        if (!isGrounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(0, 1);
        }
            
    }

    private void HandleBoundary()
    {
        transform.position = new Vector2(
        Mathf.Clamp(transform.position.x, -18.6f, 18.83f),
        Mathf.Clamp(transform.position.y, -11, 10));

        if (transform.position.y < -10)
            Alive = false;
    }

    private void Flip()
    {
        if (dirX > 0 && !facingRight || dirX < 0 && facingRight)
        {
            facingRight = !facingRight;
            var theScale = new Vector3(transform.localScale.x *-1, 1, 1);
            transform.localScale = theScale;
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
        audioSrc.clip = jumpSound;
        audioSrc.Play();
    }

    private IEnumerator Death()
    {
        respawning = true;
        Instantiate(deathPrefab, transform.position, Quaternion.identity);

        audioSrc.clip = deathSound;
        audioSrc.Play();

        rb.simulated = false;
        GetComponent<SpriteRenderer>().enabled = false;
        animator.enabled = false;

        yield return new WaitForSeconds(timeAfterDeath);

        respawning = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
            transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Moving Platform"))
            transform.parent = null;
    }
}
