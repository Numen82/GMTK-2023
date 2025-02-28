using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideScript : MonoBehaviour
{
    public float springPower = 7.5F;
    public Rigidbody2D myRigidBody;
    public SpringScript spring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Spring"))
        {
            spring = collision.GetComponent<SpringScript>();
            if (spring.Again)
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, springPower);
                spring.Again = false;
            }
        }
    }
}
