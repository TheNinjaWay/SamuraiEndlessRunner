using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterFaceManager : MonoBehaviour
{
    
    public bool isGameStarted;
    public GameObject maincamera;
    public GameObject startcamera;
    public GameObject TapToStarttext;

    void Start()
    {
        isGameStarted = false;
        
    }

   
    void Update()
    {
        if (SwipeManager.tap)
        {
            GameManager.instance.PlayerMotion.animator.SetBool("isStarted", true);
            startcamera.SetActive(false);
            maincamera.SetActive(true);
            TapToStarttext.SetActive(false);
            isGameStarted = true;
        }
    }
}
