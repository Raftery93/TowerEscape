using UnityEngine;
using System.Collections;
public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    private Animator anim;

    private bool onGround = false;

    private bool wallJump = false;

    public static int isDead = 0;

    public static int pauseCamera;

    float valueToDecrease = -0.00001f;

    float step = 0.0f;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        
        PlayerPrefs.SetInt("isDead", isDead);

        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            anim.SetBool("Grounded", onGround);
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
        if (Input.GetButtonDown("Jump") && wallJump == true)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed * 1.5f);
        }

        var cameraPosition = Camera.main.gameObject.transform.position;
        
        if ((rigidBody.position.y + 5.8) < cameraPosition.y)
        {
            isDead = 1;
            PlayerPrefs.SetInt("isDead", isDead);
            
            Time.timeScale = 0f;
            //float step = -0.01f;
            cameraPosition.y += valueToDecrease;
            Camera.main.gameObject.transform.position = cameraPosition;

        }
        else
        {
            isDead = 0;
            PlayerPrefs.SetInt("isDead", isDead);
            
        }

        if ((rigidBody.position.y - 5.8) > cameraPosition.y)
        {
            //Move camera up
        }
        
    }

    


    //Check if the object is on the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            wallJump = true;
        }
    }

    //Check if the object has left the ground
    void OnCollisionExit2D(Collision2D collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }

        if (collisionInfo.gameObject.CompareTag("Wall"))
        {
            wallJump = false;
        }
    }


}