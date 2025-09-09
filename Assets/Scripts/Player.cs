using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _anim;
    

    [Header("Move Info")]
    public bool runBegun;
    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpForce;

    [Header("Collision Info")]
    [SerializeField]
    private float groundCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool _isGrounded;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (runBegun)
        {
            _rb.linearVelocity = new Vector2(_moveSpeed, _rb.linearVelocity.y);
        }

        CheckCollision();
        CheckInput();
        AnimatorController();

    }

    void AnimatorController()
    {
        _anim.SetBool("_isGrounded", _isGrounded);
        _anim.SetFloat("xVelocity", _rb.linearVelocity.x);
        _anim.SetFloat("yVelocity", _rb.linearVelocity.y);
    }
    private void CheckCollision()
    {
        _isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void CheckInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            runBegun = true;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
    }
}
