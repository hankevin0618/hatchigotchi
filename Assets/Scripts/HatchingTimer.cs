using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HatchingTimer : MonoBehaviour
{
    // make visible in the inspector
    [SerializeField] private Text timerText;
    [SerializeField] private float mainTimer = 0;

    [SerializeField] private Sprite thisEgg;

    private Animator animator;

    public static bool hatchIt = false;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    

    

    void Start() {
        timer = mainTimer;
        
        thisEgg = GetComponent<Sprite>();
        

    }


    void Update() 
    {
        if(timer >= 0.0f && canCount && !hatchIt)
        {
            timer -= Time.deltaTime;
            
            timerText.text = "Hatching in: " + timer.ToString("0") + "s"; // f converts float to string
            
            if(timer <= 0.0f){
                hatchIt = true;
            }

        }
        else if(timer <= 0.0f || hatchIt == true) // we dont count anymore
        {
            canCount = false;
            
            timerText.text = "Hatching Now!";
            timer = 0.0f;

        }

        
    }



}
