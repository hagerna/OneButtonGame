using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gm;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();

        sr.enabled = false;
    }

    void Update()
    {
        if (gm.playerPressed)
        {
            sr.enabled = true;
            bc.enabled = true;
        }
        else 
        {
            sr.enabled = false;
            bc.enabled = false;
        }
    }
}
