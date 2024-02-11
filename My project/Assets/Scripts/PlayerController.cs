using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;  //0 1 2
    public float laneDistance = 4; // distance entre les lignes

    public float jumpForce;
    public float gravity = -20;
    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (controller.isGrounded)
        {
            //direction.y =  -1;

            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
            direction.y += gravity * Time.deltaTime;

        // inputs in which lane
        if (SwipeManager.swipeRight) {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        // calucler ou il va etre
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;
        transform.position = targetPosition;
        controller.center = controller.center;

    }
    private void FixedUpdate()
    {
        controller.Move(direction * Time.deltaTime);
    }
    private void Jump()
    {
        direction.y = jumpForce;
    }
}
