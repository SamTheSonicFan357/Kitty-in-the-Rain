using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public int jumpForce;
    public int fastFallForce;

    private Rigidbody2D rigBody;
    private bool hasJumped = false;
    private bool hasFastFalled = false;
    private bool isGrounded = false;

    private const float groundedRadius = .2f;

    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hasJumped = Input.GetKeyDown(KeyCode.Space) && isGrounded;
        hasFastFalled = Input.GetKey(KeyCode.DownArrow) && !isGrounded;
    }

    private void FixedUpdate()
    {
        isGrounded = CheckIfGrounded();

        if (hasJumped)
        {
            rigBody.AddForce(new Vector2(0f, jumpForce));
            hasJumped = false;
        }
        else if (hasFastFalled)
        {
            rigBody.AddForce(new Vector2(0f, -fastFallForce));
            hasFastFalled = false;
        }
    }

    private bool CheckIfGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
