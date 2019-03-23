using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting_2 : MonoBehaviour
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


    // Day and Night Script for 2d,
    // Unity needs one empty GameObject (earth) and one Light (sun)
    // make the sun a child of the earth
    // reset the earth position to 0,0,0 and move the sun to -200,0,0
    // attach script to sun
    // add sun and earth to script publics
    // set sun to directional light and y angle to 90


   
}