using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{

    public GameObject position0;
    public GameObject position1;

    // Update is called once per frame
    void Update()
    {

        
        
        
        
        
        
        
        //transform.position = Vector2.MoveTowards 

        Vector2 AiPosition = transform.position;

        if (transform.position.x < position0.transform.position.x)
        {   
            //if on the right go left
            AiPosition.x = AiPosition.x += 1 * Time.deltaTime;
            transform.position = AiPosition;
        }
        else
        {
             AiPosition.x = AiPosition.x -= 1 * Time.deltaTime;
            transform.position = AiPosition;
        }

        if (transform.position.y < position0.transform.position.y)
        {
            transform.position += (Vector3) Vector2.up * 1 * Time.deltaTime;
        }
        else
        {
            transform.position -= (Vector3)Vector2.up * 1 * Time.deltaTime;
        }



    }
}
