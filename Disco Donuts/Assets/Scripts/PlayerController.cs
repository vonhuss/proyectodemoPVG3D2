using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    bool isGrounded;
    public int colorIndex;
    public int score;

    private Animator anim;

    public float horizontalInput;
    public float movementSpeed = 10.0f;
    public float xRange = 14.0f;

    public Material material;

    public static PlayerController playerController;

    Rigidbody rb;

    public ParticleSystem greenExplotion;
    public ParticleSystem pinkExplotion;
    public ParticleSystem yellowExplotion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        material.color = new Color(1,0.65f,0.65f);
        colorIndex = 0;
        playerController = this;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Jump(); 
        Movement();
        ColorChange();
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            anim.Play("BouncingAnim");
        }
    }

    public void Movement()
    {
        // Set x Axis limits
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Get input from the player
        horizontalInput = Input.GetAxis("Horizontal");

        // Set movement to the player´s GO
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * movementSpeed);

    }


    public void ColorChange()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            material.color = new Color(0.043f,1,0);
            colorIndex = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            material.color = new Color(1, 0, 0.745f);
            colorIndex = 2;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            material.color = new Color(1, 1, 0);
            colorIndex = 3;
        }
            
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("GreenDonut")&& colorIndex == 1)
        {
            score ++;
            greenExplotion.Play();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("PinkDonut") && colorIndex == 2)
        {
            score++;
            pinkExplotion.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("YellowDonut") && colorIndex == 3)
        {
            score++;
            yellowExplotion.Play();
            Destroy(other.gameObject);
        }

    }
}
