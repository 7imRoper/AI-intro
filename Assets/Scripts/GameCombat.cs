using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCombat : MonoBehaviour
{

    [SerializeField] GameObject _combatCanvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        
        AIMovement aimove = collision.gameObject.GetComponent<AIMovement>();

        if (aimove == null)
        {
            return;
        }
        Debug.Log("Hit Ai");

        _combatCanvas.SetActive(true);
        Time.timeScale = 0;
    
    }


}
