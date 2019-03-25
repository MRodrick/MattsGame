using UnityEngine;
using System.Collections;
using UnityEngine.UI;	//allows use of UI.
using UnityEngine.SceneManagement;

public class Player_New : MonoBehaviour
{

    private Vector2 velocity;
    private Rigidbody2D rb2d;
    private Sprite mySprite;
    private SpriteRenderer sr;
    public float speed;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private bool facingRight = true;
    public float coins = 0;
    public GUIStyle style;
    public Rect rect;
    string text;
    void Start() {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        int w = Screen.width, h = Screen.height;

        style = new GUIStyle();

        rect = new Rect(0, 0, w - 30, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1.0f, 1.0f, 1.5f, 1.0f);
    }

    void FixedUpdate()
    {
        bool clicked = false;

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
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        text = coins.ToString();
        Debug.Log(coins);
    }

    private void OnDisable() {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            coins++;
        }
        else if (other.gameObject.tag == "End Of Level") {
            if (coins >= 10) {
                Application.Quit();

            }
            else {  }
        }
    }
    public void deductCoins(int i) {
        coins = coins - i;
    }
    public void OnGUI()
    {
        
                
        GUI.Label(rect, "Coins :" + text, style);
    }
}
