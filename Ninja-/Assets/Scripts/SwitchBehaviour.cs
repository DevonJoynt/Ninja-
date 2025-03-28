using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour doorBehaviour;

    [SerializeField] bool isDoorOpenSwitch; // switch can open door
    [SerializeField] bool isDoorCloseSwitch;  //switch can close door

    float switchSizeY;
    Vector3 switchUpPos;
    Vector3 switchDownPos;
    float switchSpeed = 1f;
    float switchDelay = 0.2f;
    bool isPressingSwitch = false;

    [SerializeField] InventoryManager.AllItems requiredItem; //need correct key to open door


    // Assign Data
    void Awake()
    {
        switchSizeY = transform.localScale.y / 2;

        switchUpPos = transform.position;
        switchDownPos = new Vector3(transform.position.x, transform.position.y - switchSizeY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressingSwitch) // moves switch down (depresses)
        {
            MoveSwitchDown();
        }
        else if (!isPressingSwitch)  // or moves switch back up to original position
        {
            MoveSwitchUp();
        }
    }
    void MoveSwitchDown()  // switch down
    {
        if (transform.position != switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchDownPos, switchSpeed * Time.deltaTime);
        }
    }
    void MoveSwitchUp()  //switch up
    {
        if (transform.position != switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchUpPos, switchSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  //activates button when jumped on
    {
        if (collision.CompareTag("Player"))
        {
            isPressingSwitch = !isPressingSwitch;

           
            if (HasRequiredItem(requiredItem))
            {
                if (isDoorOpenSwitch && !doorBehaviour.isDoorOpen)
                {
                    doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
                }
                else if (isDoorCloseSwitch && doorBehaviour.isDoorOpen)
                {
                    doorBehaviour.isDoorOpen = !doorBehaviour.isDoorOpen;
                }
            }
                       
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //controls opening and closing of door with switch
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SwitchUpDelay(switchDelay));
        }
    }
    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        isPressingSwitch = false;
    }
    public bool HasRequiredItem(InventoryManager.AllItems itemRequired) //must have required item to open or close door
    {
        if (InventoryManager.Instance.inventoryItems.Contains(itemRequired))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
