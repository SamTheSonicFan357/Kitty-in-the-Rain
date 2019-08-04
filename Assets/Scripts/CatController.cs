using UnityEngine;
using UnityEngine.UI;

public class CatController : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public int jumpForce;
    public int fastFallForce;
    public Text scoreText;
    public GameObject winMenu;

    private Rigidbody2D rigBody;
    private bool hasJumped = false;
    private bool hasFastFalled = false;
    private bool isGrounded = false;
    private int score;

    private const float groundedRadius = .2f;

    void Start()
    {
        rigBody = gameObject.GetComponent<Rigidbody2D>();
        score = 0;
        scoreText.text = "Fish: " + score;
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Collectable")
        {
            FindObjectOfType<AudioManager>().Play("ObtainedCollectable");
            Destroy(collider.gameObject);
            score++;
            scoreText.text = "Fish: " + score;
        }
        else if (collider.gameObject.tag == "House")
        {
            FindObjectOfType<AudioManager>().Play("Meow");
            winMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
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
