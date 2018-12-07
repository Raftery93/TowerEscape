using UnityEngine;
using System.Collections;
public class PlayerBehaviour : MonoBehaviour
{
    //Variables & handles to for game objects
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public AudioSource jumpSound;
    public AudioSource deadSound;
    private Animator anim;
    private bool onGround = false;
    private bool wallJump = false;
    public static int isDead = 0;
    public static int pauseCamera;
    float valueToDecrease = -0.00001f;

    //float step = 0.0f;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get value to see if player is moving for animation
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        
        //Creates playerPref for isDead
        PlayerPrefs.SetInt("isDead", isDead);

        //Get player input
        movement = Input.GetAxis("Horizontal");

        if (movement > 0f)
        {
            //Move player left
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else if (movement < 0f)
        {
            //Move player right
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
        }
        else
        {
            //No movement
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        //If input is jump and player is grounded
        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            //Play jump sound
            jumpSound.Play();

            //get value for jump animation
            anim.SetBool("Grounded", onGround);

            //Player jump
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        //Check for wall jump
        if (Input.GetButtonDown("Jump") && wallJump == true)
        {
            jumpSound.Play();

            //Larger jump for wall jump
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed * 1.5f);
        }

        //Get camera positon
        var cameraPosition = Camera.main.gameObject.transform.position;
        
        //If player is below main camera
        if ((rigidBody.position.y + 5.8) < cameraPosition.y)
        {
            //Set player isDead playerPrefs
            isDead = 1;
            PlayerPrefs.SetInt("isDead", isDead);
            
            //Pause player movement
            Time.timeScale = 0f;

            //float step = -0.01f;
            //valueToDecrease--;

            //Play dead sound
            deadSound.Play();

            //Pause camera position - doesnt work due to pause menu
            cameraPosition.y += valueToDecrease;
            Camera.main.gameObject.transform.position = cameraPosition;

        }
        else
        {
            //Else reset player is alive
            isDead = 0;
            PlayerPrefs.SetInt("isDead", isDead);
            
        }

        if ((rigidBody.position.y - 5.8) > cameraPosition.y)
        {
            //Move camera up
            //Trying to move camera up if the player hits the top of the camera
        }
        
    }

    


    //Check if the player is on the ground / wall
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

    //Check if the player has left the ground / wall
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