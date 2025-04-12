using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public float speed;   //trap movement speed
    Vector3 targetPos;   //target position trap moving towards

    public GameObject ways;   //gameobject that hold waypoints
    public Transform[] wayPoints;
    int pointIndex;
    int pointCount;
    int direction = 1;  //direction of waypoint movement

    private void Awake()
    {
        wayPoints = new Transform[ways.transform.childCount];   // Initialize waypoints array
        for (int i = 0; i < ways.gameObject.transform.childCount; i++)
        {
            wayPoints[i] = ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        pointCount = wayPoints.Length;   // Stores total number of waypoints
        pointIndex = 1;
        targetPos = wayPoints[pointIndex].transform.position;   // Set the initial target position
    }
    private void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);  // Move trap toward current target position

        if (transform.position == targetPos)   // Move to next waypoint when trap has reached current waypoint  
        {
            NextPoint();
        }
    }
    void NextPoint()
    {
        if (pointIndex == pointCount - 1)  //arrived at last point - reverse direction
        {
            direction = -1;
        }
        if (pointIndex == 0)  // arrived at first point - reverse direction
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = wayPoints[pointIndex].transform.position;
    }
    


}
