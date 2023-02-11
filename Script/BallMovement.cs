using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float forwardForce;
    public float sideForce;
    //public float rotateSpeed;
    private Rigidbody rb;
    private Vector3 moveAmount;
    private Vector3 touchPosition;
    private Vector3 direction;
    public float moveSpeed;
    public float moveX;
    Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveDirection = new Vector3(moveX, 0, 0).normalized; 
    }
    void FixedUpdate()
    {
        //rb.AddTorque(Vector3.forward);
       rb.AddForce(0,0, forwardForce * Time.deltaTime);

       /*if(Input.GetKey("a"))
       {
           rb.AddForce(-sideForce * Time.deltaTime, 0, 0);
       }
       if(Input.GetKey("d"))
       {
           rb.AddForce(sideForce * Time.deltaTime, 0, 0);
       }*/

       /*if(Input.touchCount > 0)
       {
           Touch touch = Input.GetTouch(0);
           touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
           direction = (touchPosition - transform.position);
           //touchPosition.z = 0;
           touchPosition.y = 0;
            rb.velocity = new Vector3(direction.x, 0, 0) * moveSpeed * Time.deltaTime;

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector3.zero;
            }
       }*/

       transform.position = new Vector3(Mathf.Clamp(transform.position.x + moveDirection.x * 20 * Time.deltaTime, -4.5f, 4.5f), transform.position.y, transform.position.z);

       if(Input.touchCount > 0)
       {
           Touch touch = Input.GetTouch(0);

           if(touch.phase == TouchPhase.Moved)
           {
               transform.position = new Vector3(Mathf.Clamp(transform.position.x + touch.deltaPosition.x * moveSpeed * Time.deltaTime, -4.5f, 4.5f), transform.position.y, transform.position.z);
           }
       }
    }

    //Set the ForwardSpeed
    public void SetSpeed(float modifier)
    {
        forwardForce += 100.0f * modifier;
    }
}
