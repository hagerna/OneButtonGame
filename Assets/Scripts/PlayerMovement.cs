using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    float jumpRay;
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    public Sprite[] sprites;
    bool jumping;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        ButtonReset();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = rb2D.velocity;
        float input = Input.GetAxis("Horizontal");
        float xMovement = input * speed;
        vel.x = xMovement;

        if (Input.GetKey(KeyCode.Space) && !jumping)
        {
            jumping = true;
            vel.y = jumpForce;
        }

        rb2D.velocity = vel;
        if (jumping)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, jumpRay);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.CompareTag("Platform"))
                {
                    jumping = false;
                }
            }
        }
    }

    public void ButtonPressed()
    {
        spriteRenderer.sprite = sprites[1];
        boxCollider.size = new Vector2(1, 0.75f);
        speed = 8;
        jumpForce = 7;
        jumpRay = 0.5f;
    }

    public void ButtonReset()
    {
        spriteRenderer.sprite = sprites[0];
        boxCollider.size = new Vector2(1, 1.17f);
        speed = 5;
        jumpForce = 5;
        jumpRay = 0.7f;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Danger")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
