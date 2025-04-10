using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchBehaviour : MonoBehaviour
{
    [SerializeField] DoorBehaviour doorBehaviour;
    [SerializeField] bool isDoorOpenSwitch;
    [SerializeField] bool isDoorCloseSwitch;
    float switchSizeY;
    Vector3 switchUpPos;
    Vector3 switchDownPos;
    [SerializeField] float switchSpeed = 1f;
    [SerializeField] float switchDelay = 0.2f;
    bool isPressingSwitch = false;
    [SerializeField] InventoryManager.AllItems requiredItem;

    // Add Unity Events
    [Header("Events")]
    public UnityEvent onSwitchPressed = new UnityEvent();
    public UnityEvent onSwitchReleased = new UnityEvent();
    public UnityEvent onSwitchActivated = new UnityEvent();
    public UnityEvent onSwitchDenied = new UnityEvent();

    void Awake()
    {
        switchSizeY = transform.localScale.y / 2;
        switchUpPos = transform.position;
        switchDownPos = new Vector3(transform.position.x, transform.position.y - switchSizeY, transform.position.z);
    }

    void Update()
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
        if (transform.position != switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchDownPos, switchSpeed * Time.deltaTime);

            // Check if switch just finished moving down
            if (transform.position == switchDownPos)
            {
                onSwitchPressed.Invoke();
            }
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, switchUpPos, switchSpeed * Time.deltaTime);

            // Check if switch just finished moving up
            if (transform.position == switchUpPos)
            {
                onSwitchReleased.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressingSwitch = !isPressingSwitch;

            if (HasRequiredItem(requiredItem))
            {
                // Invoke success event
                onSwitchActivated.Invoke();

                if (isDoorOpenSwitch && !doorBehaviour.isDoorOpen)
                {
                    // Use the new SetDoorState method instead of directly changing the property
                    doorBehaviour.SetDoorState(true);
                }
                else if (isDoorCloseSwitch && doorBehaviour.isDoorOpen)
                {
                    doorBehaviour.SetDoorState(false);
                }
            }
            else
            {
                // Invoke denied event
                onSwitchDenied.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
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

    public bool HasRequiredItem(InventoryManager.AllItems itemRequired)
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