using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{

    public Vector2 movement;
    [Range(0.0f, 360.0f)]
    public float viewDirection = 0.0f;
    [Range(0.0f, 360.0f)]
    public float viewFov;
    public float viewDistance;
    public float targetLost = 2.0f;
    [Header("Range Attack Data")]
    [Tooltip("From where the projectile are spawned")]
    public Transform shootingOrigin;

    private Collider2D myCollider;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Transform target;
    protected float fireRate = 0.0f;

    protected RaycastHit2D[] RaycastHitCache = new RaycastHit2D[8];


    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        Move();
    }
    private void Move() {
        rb2d.velocity = new Vector2(-4, 0);
        anim.SetTrigger("");
    }

}
