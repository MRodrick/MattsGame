﻿using System.Collections;
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
    public GameObject archer;
    int i;
    // Start is called before the first frame update
    Vector3 playerPos;

    void Start()
    {
        wheel.SetActive(false);
        i = 0;
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
        if (base.coins >= 1)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z-0.01f);
            Instantiate(Torch, pos, Quaternion.identity);
            base.DeductCoins(1);

            OnGUI();
        }
        else {
            i = 1;
            OnGUI(); }
        i = 0;
        OnGUI();
    }
    public void opt2()
    {
        if (base.coins >= 4)
        {
            InstantiateNewObject(House, 1, 3);
            base.DeductCoins(4);

            OnGUI();
        }
        else
        {
            i = 1;
            OnGUI();
        }
        i = 0;
        OnGUI();
    }
    public void opt3()
    {
        if (base.coins >= 2)
        {
            InstantiateNewObject(Wall, 1, 3);

            base.DeductCoins(2);
            OnGUI();

        }
        else
        {
            i = 1;
            OnGUI();
        }
        i = 0;
        OnGUI();
    }
    public void opt4()
    {
        if (base.coins >= 2)
        {
            InstantiateNewObject(Tent, 1, 3);


            base.DeductCoins(2);
            OnGUI();
        }
        else
        {
            i = 1;
            OnGUI();
        }
        i = 0;
        OnGUI();
    }

    public void opt5()
    {
        if (base.coins >= 3)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y, playerPos.z + 0.01f);

            Instantiate(archer, pos, Quaternion.identity);

            base.DeductCoins(4);
            OnGUI();
        }
        else {
            i = 1;
        }
        i = 0;
    }
    void OnGUI() {
        /*int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperCenter;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.5f, 1.0f);
        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        if (i == 1)
        {
            string text = string.Format("Not enough coins!");
            GUI.Label(rect, text, style);

        }
        else {
            string text = string.Format("");
            GUI.Label(rect, text, style);

        }*/
        int w = Screen.width, h = Screen.height;

        style = new GUIStyle();

        rect = new Rect(0, 0, w - 30, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.5f, 1.0f);
        GUI.Label(rect, "Coins :" + base.coins, style);
    }
    void InstantiateNewObject(GameObject prefab, int minY, int maxY)
    {
        Vector3 pos = new Vector3(playerPos.x, playerPos.y - .2f, playerPos.z + 0.01f);
        
        Instantiate(prefab, pos, Quaternion.identity);

    }
    /* void OnTriggerEnter2D(Collider2D other)
     {
         if (other.gameObject == Tent)
         {

             Destroy(other.gameObject);
         }
         if (other.gameObject.tag == "End Of Level")
         {
             // if (coins >= 10) {
             Application.Quit();

             //}
         }
     }*/
}
