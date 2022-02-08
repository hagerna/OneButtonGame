using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStairs : MonoBehaviour
{
    public GameObject[] toDisappear;
    SpriteRenderer sr;
    
    void Start()
    {
        
    }

    
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        foreach (GameObject go in toDisappear)
        {
            sr = go.GetComponent<SpriteRenderer>();
            sr.enabled = false;
            sr.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        foreach (GameObject go in toDisappear)
        {
            sr = go.GetComponent<SpriteRenderer>();
            sr.enabled = true;
            sr.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
