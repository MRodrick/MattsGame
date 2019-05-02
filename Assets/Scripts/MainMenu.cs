using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public Text text;
    public Button play;
    public Button tutorial;
    public Button controls;
    public Button quit;
    public Button back;
    public Image MainScene;
    public Image inventory;
    public int i;

    private void Start()
    {
       // text.gameObject.active = false;
       // back.gameObject.active = false;
    }
    
    public void mainMenuSelection() {
        if (i == 1)
        {
            LoadScene("GameScene1");
        }
        else if (i == 2)
        {
            ShowTutorial();
        }
        else if (i == 3)
        {

        }
        else if (i == 4) {

        }


    }

    public void LoadScene(string GameScene1)
    {
        SceneManager.LoadScene(GameScene1);
    }


    public void ShowTutorial() {
        // play.gameObject.active = false;
        back.gameObject.active = true;
        MainScene.gameObject.active = true;
        inventory.gameObject.active = true;
        play.gameObject.active = false;
        tutorial.gameObject.active = false;
        controls.gameObject.active = false;
        quit.gameObject.active = false;
        text.gameObject.active = true;
    }


    public void BackButton() {
        play.gameObject.active = true;
        tutorial.gameObject.active = true;
        controls.gameObject.active = true;
        quit.gameObject.active = true;
        back.gameObject.active = false;
        text.gameObject.active = false;
        MainScene.gameObject.active = false;
        inventory.gameObject.active = false;
    }

   // public void Quit() {
    //    Application.Quit();
   // }

}

