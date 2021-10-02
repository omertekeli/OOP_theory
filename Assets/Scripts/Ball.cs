using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Encapsulation is applied
    private float _speed = 100.0f;
    public float speed 
    { get { return _speed; }

        set
        {
            if (value < 74.0f)
            {
                Debug.LogError("Please set this value as bigger than 75");
            }
            else
            {
                _speed = value;
            }
        }
    }

    protected float yMoveBound = 2.0f;
    protected float yDestroyBound = 5.0f;
    protected Rigidbody ballRb;
    protected GameObject player;

    protected void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        MoveToPlayer();
        Destroy();
    }

    //This method will be used by Fox and Rooster classes.
    public virtual void MoveToPlayer()
    {
        

        if (transform.position.y > -yMoveBound)
        {
            ballRb.AddForce((player.transform.position - transform.position).normalized * _speed);
        }
        
    }

    //This method will be used by Fox and Rooster classes.
    public void Destroy()
    {
        if (transform.position.y < -yDestroyBound)
        {
            Destroy(gameObject);
        }
    }
}
