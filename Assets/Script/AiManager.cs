using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class AiManager : BaseManager
{
    public enum State
    {
        HighHP,
        LowHP,
        Dead,
    }

    public State currentState;
    protected PlayerManager _playerManager;
    protected override void Start()
    {
        base.Start();
        _playerManager = GetComponent<PlayerManager>();
        if (_playerManager == null)
        {
            Debug.LogError("PlayerManager not found");
        }
    }
    public override void TakeTurn()
    {
        if (_health <= 0f)
        {
            currentState = State.Dead;
        }
        switch (currentState)
        {
            case State.HighHP:
                HighHPState();
                break;
            case State.LowHP:
                LowHPState();
                break;
            case State.Dead:
                DeadState();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    protected override void EndTurn()
    {
        StartCoroutine(WaitAndEndTurn());
    }
    private IEnumerator WaitAndEndTurn()
    {
        yield return new WaitForSeconds(2f);
        _playerManager.TakeTurn();
    }
    void LowHPState()
    {
        int randomAttack = Random.Range(0, 10);
        switch (randomAttack)
        {
            case int i when i >= 0 && i <= 1:
                SelfDestruct();
                break;
            case int i when i > 1 && i <= 8:
                Rest();
                break;
            case int i when i > 8 && i <= 9:
                Shoot();
                break;
        }
        if (_health > 60f)
        {
            currentState = State.HighHP;
        }
    }
    void HighHPState()
    {
        if (_health < 40f)
        {
            currentState = State.LowHP;
            LowHPState();
            return;
        }
        //random.range for ints
        //min number ==  inclusive
        //max number == exclusive
        //20% chance to use splash
        //70% chance to use iron tail
        //10% chance to use self destruct
        int randomAttack = Random.Range(0, 10);
        switch (randomAttack)
        {
            case int i when i >= 0 && i <= 1:
                Shoot();
                break;
            case int i when i > 1 && i <= 8:
                Bomb();
                break;
            case int i when i > 8 && i <= 9:
                SelfDestruct();
                break;
        }
    }
    void DeadState()
    {
        Debug.Log("AI IS DEAD YOU WIN");
    }
    public void Shoot()
    {
        Debug.Log("Ai Shoots");
        _playerManager.DealDamage(10f);
        EndTurn();
    }
    public void Bomb()
    {
        Debug.Log("Ai drops Bomb");
        _playerManager.DealDamage(20f);
        EndTurn();
    }
    public void Rest()
    {
        Debug.Log("Ai Rests");
        Heal(10f);
        EndTurn();
    }
    public void SelfDestruct()
    {
        Debug.Log("Ai casts Self Destruct");
        DealDamage(_maxHealth);
        _playerManager.DealDamage(80f);
        EndTurn();
    }
}