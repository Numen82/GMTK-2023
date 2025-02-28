using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CreatorPlaceScript : MonoBehaviour
{
    public GameObject singleSpring;
    public GameObject multiSpring;
    public GameObject creatorDisplay;
    public CreatorDisplayScript creatorDisplayScript;
    public CreatorLogicScript creatorLogic;


    // Start is called before the first frame update
    void Start()
    {
        creatorLogic = GameObject.FindGameObjectWithTag("GameController").GetComponent<CreatorLogicScript>();
        creatorDisplayScript = creatorDisplay.GetComponent<CreatorDisplayScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && creatorDisplayScript.Equiped && !creatorLogic.IsInvActive)
        {
            if (creatorDisplayScript.springType == 0 && creatorDisplayScript.SingleSpringNum > 0)
            {
                CreateClosest(singleSpring);
                creatorDisplayScript.decreaseSingleSpring();
            }
            else if (creatorDisplayScript.springType == 1 && creatorDisplayScript.MultiSpringNum > 0)
            {
                CreateClosest(multiSpring);
                creatorDisplayScript.decreaseMultiSpring();
            }
        }
    }

    public void CreateClosest(GameObject spring)
    {
        Vector2 currPos = creatorDisplay.transform.position;

        float up = Physics2D.Raycast(currPos, Vector2.up, 20).distance;
        float right = Physics2D.Raycast(currPos, Vector2.right, 20).distance;
        float down = Physics2D.Raycast(currPos, Vector2.down, 20).distance;
        float left = Physics2D.Raycast(currPos, Vector2.left, 20).distance;
        //Debug.Log($" {up} {right} {down} {left} ");

        float lowNum = Mathf.Min(up, Mathf.Min(right, Mathf.Min(down, left)));

        if (lowNum == up)
        {
            spring.transform.Rotate(Vector3.forward * 90);
            Instantiate(spring, new Vector2(currPos.x, currPos.y + lowNum - 0.5F), spring.transform.rotation);
            spring.transform.Rotate(Vector3.forward * -90);
            Debug.Log("up");
        }
        else if ( lowNum == right)
        {
            Instantiate(spring, new Vector2(currPos.x + lowNum - 0.5F, currPos.y), spring.transform.rotation);
            Debug.Log("right");
            
        }
        else if (lowNum == down)
        {
            spring.transform.Rotate(Vector3.forward * -90);
            Instantiate(spring, new Vector2(currPos.x, currPos.y - lowNum + 0.5F), spring.transform.rotation);
            spring.transform.Rotate(Vector3.forward * 90);
            Debug.Log("down");
        }
        else if (lowNum == left)
        {
            spring.transform.Rotate(Vector3.forward * 180);
            Instantiate(spring, new Vector2(currPos.x - lowNum + 0.5F, currPos.y + lowNum), spring.transform.rotation);
            spring.transform.Rotate(Vector3.forward * -180);
            Debug.Log("left");
        }
        
    }
}
