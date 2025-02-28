using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatorDisplayScript : MonoBehaviour
{
    [SerializeField] private int singleSpringNum;
    public int SingleSpringNum
    {
        get { return singleSpringNum; }
        set { singleSpringNum = value; }
    }
    [SerializeField] private int multiSpringNum;
    public int MultiSpringNum
    {
        get { return multiSpringNum; }
        set { multiSpringNum = value; }
    }
    //0: Single, 1: Multi
    public int springType = 0;
    [SerializeField] private bool equiped = false;
    public bool Equiped
    {
        get { return equiped; }
        set { equiped = value; }
    }

    public GameObject mananger;
    public Camera mainCamera;
    public SpriteRenderer spriteRenderer;
    public Sprite singleSpringS;
    public Sprite multiSpringS;
    public Sprite currentSprite;
    public Text singleSpring;
    public Text multiSpring;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = false;
        singleSpring.text = "Amount Left: " + singleSpringNum;
        multiSpring.text = "Amount Left: " + multiSpringNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (equiped && (singleSpringNum > 0 || multiSpringNum > 0))
        {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = currentSprite;

            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            transform.position = mouseWorldPos;
        }
        else
        {
            spriteRenderer.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            equiped = false;
        }
    }

    public void setEquipedSingle()
    {
        if (singleSpringNum > 0)
        {
            springType = 0;
            currentSprite = singleSpringS;
            equiped = true;
        }
    }

    public void setEquaipedMulti()
    {
        if (multiSpringNum > 0)
        {
            springType = 1;
            currentSprite = multiSpringS;
            equiped = true;
        }
    }
    public void decreaseSingleSpring()
    {
        singleSpringNum--;
        singleSpring.text = "Amount Left: " + singleSpringNum;
    }

    public void decreaseMultiSpring()
    {
        multiSpringNum--;
        multiSpring.text = "Amount Left: " + multiSpringNum;
    }
}
