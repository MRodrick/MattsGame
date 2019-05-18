using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FinishedGame : Player_New
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player_New p = other.gameObject.GetComponent(typeof (Player_New)) as Player_New;
            Debug.Log(p.coins);
            if (p.coins >= 10)
            {
                SceneManager.LoadScene("Ending");
            }
        }

    }
}
