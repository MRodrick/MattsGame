using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Lighting : Lighting_3
{
    public Color red = Color.red;
    public Color black = Color.black;
    public Camera cm;

    // Start is called before the first frame update
    void Start()
    {
    /*    dayLength = 1440;
        dayStart = 300;
        nightStart = 1200;
        currentTime = 720;
        StartCoroutine(TimeOfDay());
        earth = gameObject.transform.parent.gameObject;
        cm = GetComponent<Camera>();*/
    }

    void Update()
    {

      /*  if (currentTime > 0 && currentTime < dayStart)
        {
            isDay = false;
            cm.backgroundColor = black;
            sun.intensity = 0;
        }
        else if (currentTime >= dayStart && currentTime < nightStart)
        {
            isDay = true;
            cm.backgroundColor = red;
            sun.intensity = 1;
        }
        else if (currentTime >= nightStart && currentTime < dayLength)
        {
            isDay = false;
            sun.intensity = 0;
            cm.backgroundColor = black;

            //   cm.backgroundColor = black;
        }
        else if (currentTime >= dayLength)
        {
            currentTime = 0;
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
            Debug.Log(hours + ":" + minutes);
            yield return new WaitForSeconds(1F / cycleSpeed);
        }*/
    }
}
