using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Wheel : Player_New
{
    public GameObject wheel;
    public GameObject Torch;
    // Start is called before the first frame update
    void Start()
    {
        wheel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            wheel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            wheel.SetActive(false);
        }
    }
    public void opt1() {


        Instantiate(Torch, new Vector3(-1.31f,1.24f,-3), Quaternion.identity);


    }
}
