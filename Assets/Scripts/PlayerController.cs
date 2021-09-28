using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] GameObject centerofMass;
    //[SerializeField] GameObject focalPoint;
    

    private float horizontalInput;
    private float verticalInput;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float turnSpeed = 150.0f;
    [SerializeField] float yBound = 2.0f;
    [SerializeField] float jumpForce;
    [SerializeField] float gravityModifier;

    private bool isOnGround = true;
     
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //focalPoint = GameObject.Find("FocalPoint");

        Physics.gravity *= gravityModifier;
        playerRb.centerOfMass = centerofMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if (isOnGround && transform.position.y > -yBound)
        {
            
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && transform.position.y > -yBound)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            isOnGround = true;
            Debug.Log("player is on plane");
        }
    }
}
