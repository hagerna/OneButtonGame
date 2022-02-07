using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerPressed;
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        playerPressed = false;
        pm = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton() {
        playerPressed = true;
        pm.ButtonPressed();
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(10f);
        playerPressed = false;
        pm.ButtonReset();
    }

}
