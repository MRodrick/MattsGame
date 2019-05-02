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
    Collider2D wall;
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

    void Update()
    {
        if (wall != null)
        {
            WallBroken(wall);
        }
        else { Move(); }
    }
    void Move() {
        float x = 0;
        x = Mathf.Abs(playerLocation.position.x - transform.position.x);
        if (x > 1)
        {
            x = playerLocation.position.x > transform.position.x ? 1 : -1;
            Debug.Log(x);
            if (x == 1)
            {

                rb2d.velocity = new Vector2(2, 0);
                anim.SetTrigger("Walk");
            }
            else if (x == -1)
            {
                facingRight = false;
                anim.SetTrigger("Walk Left"); 
                //Bodge for now till I can get the local
                //transform vector.z flip to work correctly.
                rb2d.velocity = new Vector2(-2, 0);

            }
        }

        //anim.SetTrigger("Walk");

        atPlayer(x);
        // Debug.Log(x);
    }
    void atPlayer(float x) {
        if (x > 1) { Move(); }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
          AttackPlayer();
        }
        if (other.tag == "Wall") {
            wall = other;
            AttackWall(wall);
        }
    }

    void AttackPlayer() {
        rb2d.velocity = new Vector2(0, 0);
        if (facingRight == true)
        {
            anim.SetTrigger("Attack");
        }
        else { anim.SetTrigger("Attack Left"); }
        Move(); 
    }

    void AttackWall(Collider2D wall) {
        rb2d.velocity = new Vector2(0, 0);
        if (facingRight == true)
        {
            anim.SetTrigger("Attack");
        }
        else { anim.SetTrigger("Attack Left"); }

        if (WallBroken(wall))
        {
            AttackWall(wall);
        }
    }
    bool WallBroken(Collider2D wall) {

        return false;
    }
    IEnumerator Pause(float i)
    {
        Debug.Log("waiting");
        yield return new WaitForSecondsRealtime(i);
    }
}

