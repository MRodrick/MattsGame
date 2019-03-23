using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager_Script : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("Blank");
    }

}
