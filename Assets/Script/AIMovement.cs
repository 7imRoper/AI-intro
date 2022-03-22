using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 2;

    public List<GameObject> position;
    public int positionIndex = 0;
    public GameObject wayPointPrefab;


    public float speed = 1.5f;
    public float minGoalDistance = 0.05f;


    private void Start()
    {
        NewWayPoint();
        NewWayPoint();
        NewWayPoint();
        NewWayPoint();


       
    }
   
  

    public void NewWayPoint()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);

        GameObject newPoint = Instantiate(wayPointPrefab, new Vector2(x, y), Quaternion.identity);

        position.Add(newPoint);


    }

    public void FindClosestWaypoint()
    {
        float nearest = float.PositiveInfinity;
        int nearestIndex = 0;

        for (int i = 0; i < position.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, position[i].transform.position);
            if (distance < nearest)
            {
                nearest = distance;
                nearestIndex = i;
            }
        }

        positionIndex = nearestIndex;
    }


    public bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, player.position) < chaseDistance;
    }


    public void WaypointUpdate()
    {
        if (Vector2.Distance(transform.position, position[positionIndex].transform.position) < minGoalDistance)
        {
            positionIndex++;

            if (positionIndex >= position.Count)
            {
                positionIndex = 0;
            }
        }
    }

    public void AIMoveTowards(Transform goal)
    {
   
        if (Vector2.Distance(transform.position, goal.position) > minGoalDistance)
        {
           
            Vector2 directionToGoal = (goal.position - transform.position);
            directionToGoal.Normalize();
            transform.position += (Vector3)directionToGoal * speed * Time.deltaTime;
        }
    }

}