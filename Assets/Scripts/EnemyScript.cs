using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    Transform playerLocation;
    Animator anim;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private Sprite mySprite;
    private SpriteRenderer sr;
    public float speed;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool facingRight = true;

     // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move() {
       // Debug.Log("In Move");
        //anim.SetTrigger("Idle");
        float x = 0;
        x = Mathf.Abs(playerLocation.position.x - transform.position.x);
       // Debug.Log("Dist to player " + x);
        if (x > 1)
        {
            x = playerLocation.position.x > transform.position.x ? 1 : -1;

            if (x == 1)
            {
                rb2d.velocity = new Vector2(2, 0);
                anim.SetTrigger("Walk");
            }
            if (x == -1)
            {
                rb2d.velocity = new Vector2(-2, 0);
                anim.SetTrigger("Walk");
            }
        }
        else {
           // anim.SetTrigger("Idle");
        }
        atPlayer(x);
        // Debug.Log(x);
    }
    void atPlayer(float x) {
        //Debug.Log(x);
        if (x > 1) { Move(); }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
          AttackPlayer();
        }
        if (other.tag == "Wall (Clone)") {

        }
    }

    void AttackPlayer() {
        rb2d.velocity = new Vector2(0, 0);
        anim.SetTrigger("Attack");
        Move();

    }
    IEnumerator Pause(float i)
    {
        Debug.Log("waiting");
        yield return new WaitForSecondsRealtime(i);
    }
}

