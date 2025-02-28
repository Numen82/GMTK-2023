using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollowScript : MonoBehaviour
{
    public GameObject autoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, autoPlayer.transform.position.y);
    }
}
