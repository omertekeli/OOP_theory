using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    [SerializeField] GameObject centerofMass;
    
    

    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 150.0f;
    [SerializeField] float yBound = 2.0f;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;

    private bool isOnGround = true;
    private bool isMovement;
     
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Physics.gravity *= gravityModifier;
        playerRb.centerOfMass = centerofMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJumping();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isOnGround = true;
            Debug.Log("player is on plane");
        }
    }

    //Movement
    private void PlayerMovement()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        if (isOnGround && transform.position.y > -yBound)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }

        if ((verticalInput != 0 ) && isOnGround)
        {
            playerAnim.SetFloat("Speed_f", 1.0f);

        }
        else if (verticalInput == 0 )
        {
            playerAnim.SetFloat("Speed_f", 0);
        }
    }

    //Jumping
    private void PlayerJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && transform.position.y > -yBound)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            playerAnim.SetFloat("Speed_f", 0);
            isOnGround = false;
        }
    }
}
