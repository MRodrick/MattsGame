using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_Wheel : Player_New
{
    public GameObject wheel;
    public GameObject Torch;
    public GameObject House;
    public GameObject Tent;
    public GameObject Wall;
    public GameObject Player;
    // Start is called before the first frame update
    Vector3 playerPos;

    void Start()
    {
        wheel.SetActive(false);
        playerPos = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = Player.transform.position;

        if (Input.GetKeyDown(KeyCode.I)) {
            wheel.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            wheel.SetActive(false);
        }
    }
    public void opt1() {
        Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z);
        Instantiate(Torch, pos, Quaternion.identity);
    }
    public void opt2()
    {
        Vector3 pos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        Instantiate(House, pos, Quaternion.identity);
    }
    public void opt3()
    {
        Vector3 pos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        Instantiate(Wall, pos, Quaternion.identity);
    }
    public void opt4()
    {
        Vector3 pos = new Vector3(playerPos.x, playerPos.y, playerPos.z);
        Instantiate(Tent, pos, Quaternion.identity);
    }
}
