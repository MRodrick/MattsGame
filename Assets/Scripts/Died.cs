using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Died : MonoBehaviour
{
    public GameObject paused;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0) {
            unpause();
        }*/
    }
    public void unpause() {
        Time.timeScale = 1;
        paused.SetActive(false);
    }
    public void restart(){
        SceneManager.LoadScene("GameScene1");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
