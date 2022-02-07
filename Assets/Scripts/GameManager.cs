using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerPressed;
    // Start is called before the first frame update
    void Start()
    {
        playerPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PressButton() {
        playerPressed = true;
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(5f);
        playerPressed = false;
        //Trigger player to return to normal size

    }

}
