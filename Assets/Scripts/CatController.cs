using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public int jumpForce;

    private Rigidbody2D rigBody;
    private bool hasJumped = false;
    private bool isGrounded = false;

    private const float groundedRadius = .2f;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            hasJumped = true;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
    }

    private void FixedUpdate()
    {
        isGrounded = CheckIfGrounded();

        if (hasJumped)
        {
            rigBody.AddForce(new Vector2(0f, jumpForce));
            hasJumped = false;
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
