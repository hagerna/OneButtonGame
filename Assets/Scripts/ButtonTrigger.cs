using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    GameManager gm;
    PlayerMovement pm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        pm = FindObjectOfType<PlayerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.playerPressed)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gm.playerPressed)
        {
            gm.PressButton();
        }
    }
}
