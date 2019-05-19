using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;
    private Animator anim;
    // Start is called before the first frame update
    bool inBoat = false;
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boat" || collision.tag == "Player")
        {
            Debug.Log("HIT");
            Application.Quit();
        }
    }
}
