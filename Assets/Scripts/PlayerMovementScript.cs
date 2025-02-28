using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpPower = 7F;
    public float moveSpeed = 7F;
    public float dirct;
    //Player: 0, Auto: 1
    [SerializeField] private int type;
    private float transformX, transformY;

    public SpriteRenderer sprite;
    public Animator anime;
    public PlayerWaypointScript playerS;

    private enum MovementState
    {
        idle,
        running,
        falling,
        jumping,
        still
    }

    // Start is called before the first frame update
    void Start()
    {
        playerS = GameObject.FindGameObjectWithTag("AutoPlayer").GetComponent<PlayerWaypointScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            dirct = Input.GetAxisRaw("Horizontal");
            myRigidBody.velocity = new Vector2(dirct * moveSpeed, myRigidBody.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpPower);
            }
            MovementStateUpdatePlayer();
        }
        else if (type == 1)
        {
            MovementStateUpdateAuto();
        }
        
        
    }

    public void MovementStateUpdatePlayer()
    {
        MovementState state = MovementState.idle;

        if (dirct < 0)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        else if (dirct > 0)
        {
            sprite.flipX = false;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (myRigidBody.velocity.y > 0.1F)
        {
            state = MovementState.jumping;
        }
        else if (myRigidBody.velocity.y < -0.1F)
        {
            state = MovementState.falling;
        }

        anime.SetInteger("state", (int)state);
    }

    public void MovementStateUpdateAuto()
    {
        MovementState state = MovementState.idle;

        if (playerS.Moving)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (!playerS.Right)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (myRigidBody.velocity.y > 0.1F)
        {
            state = MovementState.jumping;
        }
        else if (myRigidBody.velocity.y < -0.1F)
        {
            state = MovementState.falling;
        }

        if (playerS.isActive)
        {
            state = MovementState.still;
        }

        anime.SetInteger("state", (int)state);
    }

    //Todo
    public void returnToStart()
    {
        transform.position = Vector3.zero;
    }
}
