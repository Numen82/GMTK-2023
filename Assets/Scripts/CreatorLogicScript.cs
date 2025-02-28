using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatorLogicScript : MonoBehaviour
{
    public bool springDie = false;
    [SerializeField] private bool isInvActive = false;
    public bool IsInvActive
    {
        get { return isInvActive; }
        set { isInvActive = value; }
    }
    [SerializeField] private bool isStarted = true;
    public bool IsStarted
    {
        get { return isStarted; }
        set { isStarted = value; }
    }

    public GameObject[] inventory;
    public CreatorDisplayScript creatorDisplay;

    // Start is called before the first frame update
    void Start()
    {
        creatorDisplay = GameObject.FindGameObjectWithTag("GameDisplay").GetComponent<CreatorDisplayScript>();
        inventory = GameObject.FindGameObjectsWithTag("Inventory");
        HideInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInventory()
    {
        if (!isStarted)
        {
            if (!isInvActive)
            {
                isInvActive = true;
                foreach (GameObject item in inventory)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                HideInventory();
            }
        }
    }

    public void HideInventory()
    {
        isInvActive = false;
        foreach (GameObject item in inventory)
        {
            item.SetActive(false);
        }
    }

    public void StartSim()
    {
        isStarted = true;
        isInvActive = false;
        HideInventory();
        creatorDisplay.Equiped = false;
    }

    public void StopSim()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
