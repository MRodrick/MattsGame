using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//allows use of UI.
using UnityEngine.SceneManagement;

public class Player_New : MonoBehaviour
{
    public GameObject paused;
    public GameObject camera;
    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private Sprite mySprite;
    private SpriteRenderer sr;
  //  public float speed;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool facingRight = true;
    public int coins = 0;
    public GUIStyle style;
    public Rect rect;
    string text;
    public bool dead = false;
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        bool clicked = false;
        if (Input.GetKey(KeyCode.Escape))
        {
            if (Time.timeScale == 1 && transform.position.x != 0)
            {
                paused.SetActive(true);
               // camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                Time.timeScale = 0;
            }
            else if (Time.time == 0)
            {
                paused.SetActive(false);
                Time.timeScale = 1;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        clicked = true;
            if (Input.GetKey(KeyCode.LeftShift)) {
                rb2d.velocity = new Vector2(-4, 0);
            }
            else {
                rb2d.velocity = new Vector2(-2, 0);
            }
            if (facingRight == true)
            {
                facingRight = false;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            } animator.SetTrigger("walkRight");

            
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            clicked = true;

            if (facingRight == false)
            {
                facingRight = true;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb2d.velocity = new Vector2(4, 0);
            }
            else
            {
                rb2d.velocity = new Vector2(2, 0);
            }
            animator.SetTrigger("walkRight");
        }
        if (clicked == false) {
            rb2d.velocity = new Vector2(0, 0);
            animator.SetTrigger("startIdle");
        }
       
        text = coins.ToString();

    }

    private void OnDisable() {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
     //   Debug.Log("entered as player");

        if (other.gameObject.tag == "Coin")
        {
            coins = coins + 1;
            Destroy(other.gameObject);
        }
        
    }
  
    public void DeductCoins(int i) {
        this.coins = coins - i;

    }
   /* public void OnGUI()
    {
        

    }*/
}
