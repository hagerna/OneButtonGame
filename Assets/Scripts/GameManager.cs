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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton() {
        playerPressed = true;
        FindObjectOfType<PlayerMovement>().ButtonPressed();
        StartCoroutine(ResetButton());
    }

    IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(10f);
        playerPressed = false;
        FindObjectOfType<PlayerMovement>().ButtonReset();
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

}
