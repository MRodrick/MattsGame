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
        if (base.coins > 0)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z);
            Instantiate(Torch, pos, Quaternion.identity);

            base.deductCoins();
        }
        else {
            i = 1;
            OnGUI(); }
        i = 0;
        OnGUI();
    }
    public void opt2()
    {
        if (base.coins > 4)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z);
            Instantiate(House, pos, Quaternion.identity);

            base.deductCoins();
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
        if (base.coins > 2)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z);
            Instantiate(Wall, pos, Quaternion.identity);

            base.deductCoins();
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
        if (base.coins > 2)
        {
            Vector3 pos = new Vector3(playerPos.x, playerPos.y - .3f, playerPos.z);
            Instantiate(Tent, pos, Quaternion.identity);

            base.deductCoins();
        }
        else
        {
            i = 1;
            OnGUI();
        }
        i = 0;
        OnGUI();
    }
    void OnGUI() {
        if (i == 1) {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.UpperCenter;
            style.fontSize = h * 2 / 100;
            style.normal.textColor = new Color(1.0f, 1.0f, 1.5f, 1.0f);
            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            string text = string.Format("Not enough coins!");
            GUI.Label(rect, text, style);

        }
    }
}
