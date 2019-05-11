using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//allows use of UI.
using UnityEngine.SceneManagement;

public class Arrow : MonoBehaviour {

    private Rigidbody2D rb2d;
    Vector2 speed = new Vector2(0.5f, 0);
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-10, 2.5f);
       // Debug.Log(rb2d.velocity);

    }
    private void Update()
    {
       /* if (rb2d.velocity.x != 0)
        {
            rb2d.velocity = rb2d.velocity + speed;
        }*/
        }

}

