using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//allows use of UI.
using UnityEngine.SceneManagement;

public class Arrow : Archer {

    private Rigidbody2D rb2d;
    Vector2 speed = new Vector2(0.5f, 0);
    private GameObject me;
    private GameObject meTo;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-10, 0f);
        // Debug.Log(rb2d.velocity);
        me = GameObject.FindGameObjectWithTag("Arrow(Clone)");
        meTo = GameObject.FindGameObjectWithTag("Arrow");

    }
    private void Update()
    {
       /* if (rb2d.velocity.x != 0)
        {
            rb2d.velocity = rb2d.velocity + speed;
        }*/
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Enemy") {

        }
    }
}


