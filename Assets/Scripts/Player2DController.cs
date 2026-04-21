using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 150;
    public bool isGrounded = false;

    private float moveValue;
    private Rigidbody2D _rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null) // รับ Input from keyboard กด D +1 (ขวา), A -1 (ซ้าย)
        {
            moveValue = (Keyboard.current.dKey.isPressed ? 1f : 0) - (Keyboard.current.aKey.isPressed ? 1f : 0);
        }

        _rb.linearVelocity = new Vector2(moveValue * speed, _rb.linearVelocity.y); // ขยับโดยการเพิ่มความเร็วตามทิศทาง Input * Speed

        if (Keyboard.current.spaceKey.wasPressedThisFrame) // ปุ่มกด spacebar
        {
            _rb.AddForce(new Vector2(_rb.linearVelocity.x, jumpForce)); // เพิ่มแรงเมื่อกด spacebar กระโดด
            Debug.Log("Jump!");
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           isGrounded = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
