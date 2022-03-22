using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StateMachine : MonoBehaviour
{

    public enum State
    {
        Attack,
        Defence,
        RunAway,
        Pattrol
    }

    public State currentState;
    public AIMovement aiMovement;

    private void Start()
    {
        aiMovement = GetComponent<AIMovement>();

        NextState();
    }

    private void NextState()
    {
        switch (currentState)
        {
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Defence:
                StartCoroutine(DefenceState());
                break;
            case State.RunAway:
                StartCoroutine(RunAwayState());
                break;
            case State.Pattrol:
                StartCoroutine(Pattrol());
                break;
        }
    }
    private IEnumerator AttackState()
    {
        
        while (currentState == State.Attack)
        {
            aiMovement.AIMoveTowards(aiMovement.player);
            if (!aiMovement.IsPlayerInRange())
            {
                currentState = State.Pattrol;
            }

            yield return null;
        }
      
        NextState();
    }

    private IEnumerator DefenceState()
    {


        float timeOfLastSpawn = Time.time;
        while (currentState == State.Defence)
        {

            //spawns next waypoint
            if (timeOfLastSpawn + 3f < Time.time)
            {
               
                timeOfLastSpawn = Time.time;
            }

            yield return null;
            
        }
        NextState();
    }

    private IEnumerator RunAwayState()
    {
       
        while (currentState == State.RunAway)
        {
           

            yield return null;
        }
        
        NextState();
    }

    private IEnumerator Pattrol()
    {
       

        aiMovement.FindClosestWaypoint();

        while (currentState == State.Pattrol)
        {
            aiMovement.WaypointUpdate();
            aiMovement.AIMoveTowards(aiMovement.position[aiMovement.positionIndex].transform);
            if (aiMovement.IsPlayerInRange())
            {
                currentState = State.Attack;
            }




            yield return null;
        }
        
        NextState();
    }

}