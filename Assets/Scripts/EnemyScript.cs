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
   // private Sprite mySprite;
   // private SpriteRenderer sr;
    public float speed;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool facingRight = true;
    private int wallAttacks = 0;
    Collider2D wall;
    GameObject wallObject;
    public WallHealth aWall;
    //  GameObject arrow;
    private int health = 100;
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
        //Debug.Log(wall);
        //  Debug.Log("wallHealth" + aWall.curHealth);
        if (health <= 0) {
            anim.SetTrigger("Die");
            new WaitForSecondsRealtime(2f);
            Destroy(this.gameObject);
        }
        if (wall != null)
        {
            WallBroken();
        }
        else {
            Move(); }
    }
    void Move() {
        float x = 0;
        x = Mathf.Abs(playerLocation.position.x - transform.position.x);
        if (x > 1)
        {
            x = playerLocation.position.x > transform.position.x ? 1 : -1;
            //Debug.Log(x);
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
       // Debug.Log(other.tag);
        rb2d.velocity = new Vector2(0, 0);
        if (other.tag == "Player")
        {
            AttackPlayer(other.gameObject);
        }

        else if (other.tag == "Wall")
        {
            wallObject = other.gameObject;
            // Debug.Log(wallObject.tag);

            wall = other;
            aWall = wallObject.GetComponent<WallHealth>();

            AttackWall(wall);


            //  Debug.Log(aWall.curHealth);
        }
        else if (other.tag == "Archer") {
            AttackArcher(other.gameObject);
        }
        else if (other.tag == "Arrow")
        {
            Injured();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      //  Debug.Log(collision.tag);
        Move();
  //      if (collision.tag == "Player") { Move(); }
    }

    void AttackPlayer(GameObject p) {
        rb2d.velocity = new Vector2(0, 0);
        if (facingRight == true)
        {
            anim.SetTrigger("Attack");
        }
        else { anim.SetTrigger("Attack Left"); }
        p.SetActive(false);
    }

    void AttackArcher(GameObject a) {
        rb2d.velocity = new Vector2(0, 0);
        if (facingRight == true)
        {
            anim.SetTrigger("Attack");
        }
        else { anim.SetTrigger("Attack Left"); }
        a.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
  //      Debug.Log(other.tag);
        if (other.tag == "Wall")
        {
            wall = other;
            AttackWall(wall);
        }
    }
    private void Injured() {
        health = health - 15;
        Debug.Log(health);
        if (health <= 0)
        {
            anim.SetTrigger("Die");
        }
        else { anim.SetTrigger("Hit"); }
        
        
    }

    void AttackWall(Collider2D wall) {
        
        if (facingRight == true)
        {
            anim.SetTrigger("Attack");
        }
        else { anim.SetTrigger("Attack Left"); }
        aWall.curHealth -= 0.5f;
        rb2d.velocity = new Vector2(-0.5f, 0);

    }
    bool WallBroken() {
        if (aWall.curHealth == 0)
        {
            wallAttacks = 0;
            wallObject.SetActive(false);
            wall = null;
            wallObject = null;
            Move();

            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Pause(float i)
    {
        //Debug.Log("waiting");
        yield return new WaitForSecondsRealtime(i);
    }
}

