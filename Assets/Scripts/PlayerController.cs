using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;
    [SerializeField] protected float _jumpHeight;
    [SerializeField] private LayerMask _mask;

    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private float _jumpForce;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpForce = Mathf.Sqrt(_jumpHeight * (-2) * (Physics2D.gravity.y * _rigidbody.gravityScale));
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, _mask))
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
                _animator.SetTrigger("Jump");
            }
        }

        _rigidbody.velocity = new Vector2(horizontalInput * _movingSpeed, _rigidbody.velocity.y);
        
        if (horizontalInput != 0)
        {
            _animator.SetBool("Run", true);
        }
        else
        {
            _animator.SetBool("Run", false);
        }
    }
}
