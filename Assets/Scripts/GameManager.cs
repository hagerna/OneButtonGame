using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool playerPressed;
    public string[] scenes;
    int currentScene;
    public bool skipCutScene;
    public bool DestroyonLoad;

    private void Awake()
    {
        if (!DestroyonLoad)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        playerPressed = false;
        currentScene = 1;
        StartCoroutine(IntroCutscene());
    }

    public void PressButton() {
        playerPressed = true;
        FindObjectOfType<PlayerMovement>().ButtonPressed();
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            if (!playerPressed)
            {
                yield break;
            }
        }
        if (playerPressed) {
            FindObjectOfType<PlayerMovement>().ButtonReset();
        }
        playerPressed = false;
    }

    IEnumerator IntroCutscene()
    {
        if (!skipCutScene)
        {
            yield return new WaitForSeconds(38f);
        }
        SceneManager.LoadScene(scenes[currentScene]);
        FindObjectOfType<AudioManager>().Play("Music");
    }

    public void LevelComplete()
    {
        currentScene++;
        SceneManager.LoadScene(scenes[currentScene]);
        playerPressed = false;
    }

    public void LevelReset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerPressed = false;
        FindObjectOfType<PlayerMovement>().ButtonReset();
    }


}
