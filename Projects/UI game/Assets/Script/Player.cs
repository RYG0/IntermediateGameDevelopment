using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Player: MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;
    private Rigidbody2D player;
    public Rigidbody2D rb;
    /*
    public float jumpAmount = 10;
    */
    public float jumpSpeed = 8f;
    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    private int score = 0;

    public Text scoreText;
    public HealthBar healthbar;
    public UnityEvent Ontrigger;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        isTouchingGround = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, groundLayer);

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-40f, 40f);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(40f, 40f);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
        */
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }

        if(score >= 25)
        {
            Ontrigger.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            score += 1;
            scoreText.text = "Score: " + score;
            collision.gameObject.SetActive(false);
        }
        else if (collision.tag == "Spice")
        {
            healthbar.Damage(0.1f);
            collision.gameObject.SetActive(false);
        }
    }
}

