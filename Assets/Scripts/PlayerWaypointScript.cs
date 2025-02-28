using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWaypointScript : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currIndex = 0;
    private float moveSpeed = 5F;
    public bool isActive;
    [SerializeField] private float transformX, transformY;

    private bool moving = true;
    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }
    private bool right = true;
    public bool Right
    {
        get { return right; }
        set { right = value; }
    }

    public Rigidbody2D myRigidBody;
    public CreatorLogicScript creatorScript;
    public CreatorDisplayScript creatorDisplay;

    // Start is called before the first frame update
    void Start()
    {
        creatorScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<CreatorLogicScript>();
        creatorDisplay = GameObject.FindGameObjectWithTag("GameDisplay").GetComponent<CreatorDisplayScript>();
        isActive = creatorScript.IsInvActive || creatorDisplay.Equiped || !creatorScript.IsStarted;
        transform.position = new Vector3(transformX, transformY);
    }

    // Update is called once per frame
    void Update()
    {
        isActive = !creatorScript.IsStarted || creatorScript.IsInvActive || creatorDisplay.Equiped;

        if (Vector2.Distance(waypoints[currIndex].transform.position, transform.position) < 0.1F)
        {
            currIndex++;
            if (currIndex > waypoints.Length - 1)
            {
                currIndex = 0;
            }
        }

        if (!isActive)
        {
            //myRigidBody.MovePosition(waypoints[currIndex].transform.position * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currIndex].transform.position, moveSpeed * Time.deltaTime);
            transformX = transform.position.x;
            transformY = transform.position.y;
        }
        
        if (currIndex == 1 && !isActive)
        {
            moving = true;
            right = true;
        }
        else if (currIndex == 0 && !isActive)
        {
            moving = true;
            right = false;
        }
    }
}
