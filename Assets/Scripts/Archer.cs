using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{

 /*   public Vector2 movement;
    [Range(0.0f, 360.0f)]
    public float viewDirection = 0.0f;
    [Range(0.0f, 360.0f)]
    public float viewFov;
    public float viewDistance;
    public float targetLost = 2.0f;
    [Header("Range Attack Data")]
    [Tooltip("From where the projectile are spawned")]
    public Transform shootingOrigin;
    */
    private Collider2D myCollider;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform target;
    protected float fireRate = 0.0f;
    public GameObject arrow;
    public GameObject spawnedArrow;
    private GameObject enemy;
    private GameObject enemyClone;
    private bool atWall = false;
    [Range(0.0f, 30.0f)]
    public float range;

    //  protected RaycastHit2D[] RaycastHitCache = new RaycastHit2D[8];


    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
        Move();
    }
    private void Update()
    {
    if(enemy == null){
            enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
        spawnedArrow = GameObject.FindGameObjectWithTag("Arrow");
        if (checkForObstacle(range) && spawnedArrow == null)
        {
            fire();
        }
        else {
            Move();
        }
    }
    private void Move()
    {
        if (!atWall)
        {
            rb2d.velocity = new Vector2(-4, 0);
            anim.SetTrigger("Run");
        }
        else{
            rb2d.velocity = new Vector2(0, 0);
            anim.SetTrigger("Idle");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            atWall = true;
        }
     
    }
    private void OnColliderStay2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            rb2d.velocity = new Vector2(0, 0);
            anim.SetTrigger("Idle");
            atWall = true;
        }
    }
    private void fire() {
        anim.SetTrigger("Fire");
        new WaitForSeconds(10f);
        Instantiate(arrow, new Vector3(transform.position.x, 2, -4), Quaternion.identity);

    }
    public bool checkForObstacle(float distance)
    {
        if (Mathf.Abs(enemy.transform.position.x - transform.position.x) > distance)
        {
            return false;
        }
        else { return true; }

    }
}
