using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private GameManager gm;
    private SpriteRenderer sr;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = FindObjectOfType<SpriteRenderer>();

        sr.enabled = false;
    }

    void Update()
    {
        if (gm.playerPressed) 
        {
            sr.enabled = true;
            transform.position = new Vector2(1.3f, -2.59f);
        }
    }
}
