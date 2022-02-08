using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingBlock : MonoBehaviour
{
    GameManager gm;
    SpriteRenderer sr;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if (gm.playerPressed)
        {
            sr.enabled = false;
            sr.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            sr.enabled = true;
            sr.GetComponent<Collider2D>().enabled = true;
        }
    }
}
