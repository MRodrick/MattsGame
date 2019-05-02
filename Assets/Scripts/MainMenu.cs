using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Text text;
    private void Start()
    {
        text.gameObject.active = false;
    }
    public int i;
    public void mainMenuSelection() {
        if (i == 1)
        {
            LoadScene("GameScene1");
        }
        else if (i == 2) {
         //   ShowTutorial();
        }


    }

    public void LoadScene(string GameScene1)
    {
        SceneManager.LoadScene(GameScene1);
    }
    public void ShowTutorial(UnityEngine.UI.Text text) {
        text.gameObject.active = !text.gameObject.active;
    }
}

