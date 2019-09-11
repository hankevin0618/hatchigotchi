using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HatchingTimer : MonoBehaviour
{
    // make visible in the inspector
    [SerializeField] private Text timerText;
    [SerializeField] private float mainTimer = 0;



    public float timer;
    private bool canCount = true;
    private bool doOnce = false;
    

    void Start() {
        timer = mainTimer;
        

    }


    void Update() 
    {
        if(timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            
            timerText.text = "Hatching in: " + timer.ToString("0"); // f converts float to string
            

        }
        else if(timer <= 0.0f && !doOnce) // we dont count anymore
        {
            canCount = false;
            doOnce = true;
            timerText.text = "Hatching Now!";
            timer = 0.0f;

        }

        
    }



}
