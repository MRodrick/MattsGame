using UnityEngine;
using System.Collections;

public class Move_Camera : MonoBehaviour
{

    public GameObject Player;       //Public variable to store a reference to the player game object
    private Vector3 start = new Vector3(-55, 3.9f, -10);
    Animator anim;
    private Vector3 offset;         //Private variable to store the offset distance between the player and camera
    bool cut = true;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("StartGame");
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - Player.transform.position;
        StartCoroutine("OpeningCutscene");
    }
   private IEnumerator OpeningCutscene() {
        transform.position = start;
        Debug.Log(transform.position);
        yield return new WaitForSeconds(10f);
        anim.SetTrigger("Normal");
        cut = false;
        
    }


    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (!cut) { transform.position = Player.transform.position + offset; }
    }
}