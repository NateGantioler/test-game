using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] Waypoints;
    private int currentWaypointIndex = 0;
    private Object timeManager;

    [SerializeField] private float speed = 2f;
    private float baseSpeed;

    private void Start() 
    {
        baseSpeed = speed;
    }

    private void Update()
    {
        speed = baseSpeed * TimeManagerScript.TimeScale;

        if(Vector2.Distance(Waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= Waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
