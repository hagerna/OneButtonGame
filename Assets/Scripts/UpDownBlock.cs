using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownBlock : MonoBehaviour
{
    public float speed;
    public float minY;
    public float maxY;
    bool goesUp = true;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y >= maxY)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            goesUp = false;
        }
        else if (transform.position.y <= minY)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            goesUp = true;
        }
        else if (transform.position.y < maxY && !goesUp)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else if (transform.position.y > minY && goesUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        
    }
}
