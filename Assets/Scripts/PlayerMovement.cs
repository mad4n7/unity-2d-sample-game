using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private float _directionX = 0f;
    
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float jumpForce = 14f;
    
    // audio
    [SerializeField] private AudioSource jumpSFX;
    
    private enum MovementState
    {
        Idle,
        Running,
        Jumping,
        Falling
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _directionX = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2( moveSpeed * _directionX, _rb.velocity.y);
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Jump!");
            _rb.velocity = new Vector2(_rb.velocity.x,jumpForce);
            jumpSFX.Play();
        }
        UpdateAnimationState();
    }
    
    private void UpdateAnimationState()
    {
        MovementState state;
        if (_directionX > 0f)
        {
            Debug.Log("Moving Right!");
            _spriteRenderer.flipX = false;
            state = MovementState.Running;
        }
        else if (_directionX < 0f)
        {
            Debug.Log("Moving Left!");
            _spriteRenderer.flipX = true;
            state = MovementState.Running;
        }
        else
        {
            Debug.Log("Idle!");
            state = MovementState.Idle;
        }
        
        if (_rb.velocity.y > .1f)
        {
            state = MovementState.Jumping;
        }
        else if (_rb.velocity.y < -.1f)
        {
            state = MovementState.Falling;
        }
        
        _animator.SetInteger("state", (int) state);
    }
    
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
