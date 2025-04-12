using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour doorBehaviour;  //door is controlled by this switch
    [SerializeField] bool isDoorOpenSwitch;   //determines if this switch opens door
    [SerializeField] bool isDoorCloseSwitch;   //determines if this switch closes door

    float switchSizeY;
    Vector3 switchUpPos;   //unpressed position
    Vector3 switchDownPos;   //pressed position

    [SerializeField] float switchSpeed = 1f;   //speed switch moves when presses
    [SerializeField] float switchDelay = 0.2f;   //delay before switch released

    bool isPressingSwitch = false;   //is switch currently being pressed
    [SerializeField] InventoryManager.AllItems requiredItem;  //item needed in inventory for switch to work

    // Add Unity Events
    [Header("Events")]
    public UnityEvent onSwitchPressed = new UnityEvent();  //event fires when swithc is pressed
    public UnityEvent onSwitchReleased = new UnityEvent();   //event fires when switch is released
    public UnityEvent onSwitchActivated = new UnityEvent();   //event fires when switch is activated
    public UnityEvent onSwitchDenied = new UnityEvent();   //event fires when missing required item

    void Awake()
    {
        switchSizeY = transform.localScale.y / 2;
        switchUpPos = transform.position;   //sets the up position
        switchDownPos = new Vector3(transform.position.x, transform.position.y - switchSizeY, transform.position.z);   //sets the down position
    }

    void Update()   //visual animation of switch
    {
        if (isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else if (!isPressingSwitch)
        {
            MoveSwitchUp();
        }
    }

    void MoveSwitchDown()
    {
        if (transform.position != switchDownPos)  //only moves if not at target position
        {
            transform.position = Vector3.MoveTowards(transform.position, switchDownPos, switchSpeed * Time.deltaTime);

            // event triggered when switch reaches down position
            if (transform.position == switchDownPos)
            {
                onSwitchPressed.Invoke();
            }
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != switchUpPos)    //only moves if not at target position
        {
            transform.position = Vector3.MoveTowards(transform.position, switchUpPos, switchSpeed * Time.deltaTime);

            // event triggered when switch reaches up position
            if (transform.position == switchUpPos)
            {
                onSwitchReleased.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))   //responds to player collisions
        {
            isPressingSwitch = !isPressingSwitch;

            if (HasRequiredItem(requiredItem))   //checks if player has required item to activate the switch
            {
                // Invoke success event
                onSwitchActivated.Invoke();

                if (isDoorOpenSwitch && !doorBehaviour.isDoorOpen)   //handles door opening
                {
                    
                    doorBehaviour.SetDoorState(true);
                }
                else if (isDoorCloseSwitch && doorBehaviour.isDoorOpen)   //handles door closing
                {
                    doorBehaviour.SetDoorState(false);
                }
            }
            else
            {
                // Invoke denied event (if missing required item)
                onSwitchDenied.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))   //responds to player collisions
        {
            StartCoroutine(SwitchUpDelay(switchDelay));   //delay switch release after player leaves
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);   //wait for specific time

        isPressingSwitch = false;   //release the switch
    }

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
    {
        if (InventoryManager.Instance.inventoryItems.Contains(itemRequired))   //check if items exists in player inventory
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}