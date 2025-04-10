using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DoorStateEvent : UnityEvent<bool> { }

public class DoorBehaviour : MonoBehaviour
{
    public bool isDoorOpen = false;
    Vector3 doorClosedPos;
    Vector3 doorOpenPos;
    [SerializeField] float doorSpeed = 10f;

    // Add Unity Events
    [Header("Events")]
    public DoorStateEvent onDoorStateChanged = new DoorStateEvent();
    public UnityEvent onDoorOpened = new UnityEvent();
    public UnityEvent onDoorClosed = new UnityEvent();

    void Awake()
    {
        doorClosedPos = transform.position;
        doorOpenPos = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
    }

    void Update()
    {
        if (isDoorOpen)
        {
            OpenDoor();
        }
        else if (!isDoorOpen)
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorOpenPos, doorSpeed * Time.deltaTime);

            // Check if door just finished opening
            if (transform.position == doorOpenPos)
            {
                onDoorOpened.Invoke();
            }
        }
    }

    void CloseDoor()
    {
        if (transform.position != doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, doorClosedPos, doorSpeed * Time.deltaTime);

            // Check if door just finished closing
            if (transform.position == doorClosedPos)
            {
                onDoorClosed.Invoke();
            }
        }
    }

    // Method to set door state with event
    public void SetDoorState(bool open)
    {
        if (isDoorOpen != open)
        {
            isDoorOpen = open;
            onDoorStateChanged.Invoke(open);
        }
    }
}