using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : Enemy
{
    [SerializeField] GameObject[] waypoints;
    [SerializeField] GameObject destination;
    [SerializeField] bool choosingRandoWaypoint = true;
    [SerializeField] int currentWaypoint = 0; //choose in Inspector which Patrol Point to start with
    [SerializeField] bool isWaiting = true;

    
    [Range (0f, 5f)]
    [SerializeField]float speed = 1;

    public void SetDestination(GameObject go)
    {
        destination = go;
    }

    public GameObject GetDestination()
    {
        return destination;
    }

    public bool GetIsWaiting() 
    {
        return isWaiting;
    }

    int GetRandomInt()
    {
        int rando;
        rando = Random.Range(0, waypoints.Length);
        return rando;
    }

    void ChooseNextDestination()
    {
        if (choosingRandoWaypoint)
        {
            SetDestination(waypoints[GetRandomInt()]);
        }
        else
        {
            if (currentWaypoint < waypoints.Length)
            {
                SetDestination(waypoints[currentWaypoint]);
                currentWaypoint++;
            }
            else
            {
                currentWaypoint = 0;
                SetDestination(waypoints[currentWaypoint]);
            }
        }
    }

    void CheckIfArrived()
    {
        if (transform.position == destination.transform.position)
        {
            ChooseNextDestination();
        }
    }

    public Vector2 GetVector2()
    {
        Vector2 newDestination;
        newDestination = new Vector2(destination.transform.position.x, destination.transform.position.y);
        return newDestination;
    }

    public void MoveToWaypoint(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        CheckIfArrived();
    }
}
