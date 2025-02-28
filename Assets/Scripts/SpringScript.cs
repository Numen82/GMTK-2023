using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
{
    //Single: 0, Multi: 1
    [SerializeField] private int type;
    public int Type
    {
        get { return type; }
        set { type = value; }
    }
    [SerializeField] private bool again;
    public bool Again
    {
        get { return again; }
        set { again = value; }
    }

    public Animator anime;
    public CreatorLogicScript creatorLogic;

    // Start is called before the first frame update
    void Start()
    {
        again = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Fix: Make it so that when you are in the collider after it triggers it doesn't break
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AutoPlayer"))
        {
            anime.SetTrigger("activated");

            if (type == 1)
            {
                anime.SetBool("againActive", true);
            }
        }
    }

    public void ResetBool()
    {
        anime.SetBool("againActive", false);
        again = true;
    }

    public void ResetTrigger()
    {
        anime.ResetTrigger("activation");
    }
}
