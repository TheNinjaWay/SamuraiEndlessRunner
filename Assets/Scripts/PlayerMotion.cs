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
    private bool isSlading;
    public Animator animator;
    public AudioManager audioManager;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        //audioManager = GameManager.instance.playerGameObject.GetComponent<AudioManager>();
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        if (!GameManager.instance.interfaceManager.isGameStarted)
        {
            return;
        }
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
            if (SwipeManager.swipeUp)
            {
                animator.SetBool("isSlading", false);
                Jump();
            }
        }

        if (SwipeManager.swipeDown && isSlading == false)
        {
            animator.SetBool("isJumping", false);
            StartCoroutine(Slider());
        }

        if (SwipeManager.swipeRight)
        {
            desiredlane++;
            if (desiredlane ==3)
            {
                desiredlane = 2;
            }
            
        }
        if (SwipeManager.swipeLeft)
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
        audioManager.PlayJump();
        isJumping = true;
        dir.y = JumpForce;
       
    }

    IEnumerator Slider()
    {
        isSlading = true;
        animator.SetBool("isSlading",true);
        yield return new WaitForSeconds(1.15f);
        animator.SetBool("isSlading", false);
        isSlading = false;
    }
}
