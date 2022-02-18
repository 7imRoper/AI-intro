using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        Movement();

    }



    private void Movement()
    {
        Vector2 movedirection = Vector2.zero;



        if (Input.GetKey(KeyCode.W))
        {
            movedirection.y += speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.S))
        {
            movedirection.y -= speed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.D))
        {
            movedirection.x += speed * Time.deltaTime;

        }
        else if (Input.GetKey(KeyCode.A))
        {
            movedirection.x -= speed * Time.deltaTime;
        }

        transform.position += (Vector3)movedirection;

        movedirection.Normalize();
        movedirection *= (speed * Time.deltaTime);
    }



}
