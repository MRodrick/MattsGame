﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_3 : MonoBehaviour
{
    private int dayLength;   //in minutes
    private int dayStart;
    private int nightStart;   //also in minutes
    private int currentTime;
    public float cycleSpeed;
    private bool isDay;
    private Vector3 sunPosition;
    public Light sun;
    public GameObject earth;

    public Color day = Color.red;
    public Color black = Color.black;
    public Camera cm;
    public float duration = 5.0f;
    public bool switched;
    public float t = 0f;
    public float intense = 0f;
  
    void Start()
    {
        dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 720;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;
        switched = false;
        sun.intensity = intense;

    }

    void Update()
    {
        if (currentTime > 0 && currentTime < dayStart)
        {
            isDay = false;
            if (switched == true)
            {
                cm.backgroundColor = Color.Lerp(day, black, t);
                t += 0.005f;
               // intense -= 0.005f;
                sun.intensity = 0;
                if (t >= 1)
                {
                    switched = false;
                    t = 0;
                }

            }

        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            
            isDay = true;
            if (switched == false)
            {
                cm.backgroundColor = Color.Lerp(black, day, t);
                t += 0.005f;
                intense = t;
                sun.intensity = intense;

                if (t >= 1) {
                    switched = true;
                    t = 0;
                }
                
            }
           
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            isDay = false;
            //sun.intensity = 0;
            if (switched == true)
            {
                cm.backgroundColor = Color.Lerp(day, black, t);
                t += 0.005f;
                intense -= 0.005f;
                sun.intensity = intense;
                if (t >= 1)
                {
                    switched = false;
                    t = 0;
                }

            }
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
            switched = false;

        }
        float currentTimeF = currentTime;
        float dayLengthF = dayLength;
        earth.transform.eulerAngles = new Vector3(0, 0, (-(currentTimeF / dayLengthF) * 360) + 90);
    }

    IEnumerator TimeOfDay()
    {
        while (true)
        {
            currentTime += 1;
            int hours = Mathf.RoundToInt(currentTime / 60);
            int minutes = currentTime % 60;
            yield return new WaitForSeconds(1F / cycleSpeed);
        }
    }
}