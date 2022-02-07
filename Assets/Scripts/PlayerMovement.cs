using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
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
        speed = 6;
        jumpForce = 5;
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
            RaycastHit2D hit = Physics2D.Raycast(transform.position + new Vector3(0,-0.5f,0), Vector2.down, 0.2f);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider);
                if (hit.collider.CompareTag("Platform"))
                {
                    Debug.Log(hit.collider);
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
    }

    public void ButtonReset()
    {
        spriteRenderer.sprite = sprites[0];
        boxCollider.size = new Vector2(1, 1.17f);
        speed = 5;
        jumpForce = 5;
    }
}
