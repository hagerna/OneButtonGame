using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerPressed;
    PlayerMovement pm;
    public string[] scenes;
    int currentScene;
    public bool skipCutScene;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerPressed = false;
        pm = FindObjectOfType<PlayerMovement>();
        currentScene = 1;
        StartCoroutine(IntroCutscene());
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

    IEnumerator IntroCutscene()
    {
        if (!skipCutScene)
        {
            yield return new WaitForSeconds(38f);
        }
        SceneManager.LoadScene(scenes[currentScene]);
    }

    public void LevelComplete()
    {
        currentScene++;
        SceneManager.LoadScene(scenes[currentScene]);
    }

}
