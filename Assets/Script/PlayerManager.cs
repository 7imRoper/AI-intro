using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager
{
    private AiManager _aiManager;

    [SerializeField] protected CanvasGroup _buttonGroup;

    protected override void Start()
    {
        base.Start();
        _aiManager = GetComponent<AiManager>();

        if (_aiManager == null)
        {
            Debug.Log("no aimanager");
        }

        if (_buttonGroup == null)
        {
            Debug.Log("no Buttongroup");
        }
    }

    public override void TakeTurn()
    {
        _buttonGroup.interactable = true;
        Debug.Log("player turn");
    }

    protected override void EndTurn()
    {
        _buttonGroup.interactable = false;
        _aiManager.TakeTurn();
    }

    public void Shoot()
    {
        _aiManager.DealDamage(10f);
        EndTurn();
    }

    public void Bomb()
    {
        _aiManager.DealDamage(20f);
        EndTurn();
    }

    public void Rest()
    {
        Heal(10f);
        EndTurn();
    }

    public void SelfDestruct()
    {
        DealDamage(_maxHealth);
        _aiManager.DealDamage(80f);
        EndTurn();
    }




}
