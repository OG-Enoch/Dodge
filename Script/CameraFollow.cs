using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform ball;
    public Vector3 offset;
    public float speed;
    private Rigidbody rb;
    private Vector3 moveVector;
    private float transition = 0f;
    private float animationDuration = 2.0f;
    private Vector3 animationOffset = new Vector3(0, -5, -5);

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = ball.position + offset;
        //x
        moveVector.x = 0;
        //y
        moveVector.y = Mathf.Clamp(moveVector.y, 3,15);
        transform.position = moveVector;

        /*if(transition > 1.0f)
        {
            
        }
        else
        {
            //Animation at the start of the game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(ball.position + Vector3.up);
        }*/

         
        //rb.AddForce(0, 0,  speed);
    }

}
