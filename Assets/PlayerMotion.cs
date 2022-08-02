using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 dir;
    public float speed;

    private int desiredlane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4;
    public float JumpForce;
    public float Gravity = -20;
    private bool isJumping;
    private Animator animator;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }


    void Start()
    {
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        dir.z = speed;
        dir.y += Gravity * Time.deltaTime;
        controller.Move(dir * Time.deltaTime);
        LaneSwipe();
    }

    public void LaneSwipe()
    {
        if (controller.isGrounded)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            desiredlane++;
            if (desiredlane ==3)
            {
                desiredlane = 2;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            desiredlane--;
            if (desiredlane == -1)
            {
                desiredlane = 0;
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredlane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredlane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);

    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);
        isJumping = true;
        dir.y = JumpForce;
       
    }
}
