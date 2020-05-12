using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private GameObject player;

    private float moveDirection;

    public Vector3 scaleChange;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        player = GetComponent<GameObject>();

        OSCHandler.Instance.Init (); // Start Open Sound Control (OSC)

    }

    // Update is called once per frame
    void Update()
    {

        //Changes the size of the character in runtime
        player.transform.localScale += scaleChange;

        //Detects if player is touching the "ground" any platform
        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        moveDirection = Input.GetAxis("Horizontal");

        //Move left or right
        myRigidbody.velocity = new Vector2(moveDirection * moveSpeed, myRigidbody.velocity.y);

        //Jump controls
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (grounded)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

    }

    //When the ninja collides with something enter this function
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "die")
        {
            SceneManager.LoadScene(2);      //Load game over scene when character colides with die objects
            OSCHandler.Instance.SendMessageToClient ("pd", "/event", "die"); //Send message "die" to OSC
        }
        else if (collision.gameObject.tag == "coin")
        {
            Debug.Log("coin detected");
            Destroy(collision.gameObject);
            ScoreScript.scoreValue += 1;
            OSCHandler.Instance.SendMessageToClient ("pd", "/event", "coin"); //send message "coin" to OSC
            OSCHandler.Instance.SendMessageToClient ("pd", "/score", ScoreScript.scoreValue);
        }
    }
}
