using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HatchingTimer : MonoBehaviour
{
    // make visible in the inspector
    [SerializeField] private Text timerText;

    private Animator animator;
    public static float hatchTimer = 3000;
    public static bool hatchIt = false;
    
    

    

    void Start() {
        if(GetTheCode.newUser) // from GetTheCode.cs
        {
            TimeMaster.instance.SaveDate();
            hatchTimer = 3000;
            GetTheCode.newUser = false;
            
        } 

         hatchTimer -= TimeMaster.instance.CheckDate();
        
        

    }


    void Update() 
    {

        if(hatchTimer >= 0.0f && !hatchIt)
        {
            //timer -= TimeMaster.instance.CheckDate();
            hatchTimer -= Time.deltaTime;
            
            timerText.text = "Hatching in: " + hatchTimer.ToString("0") + "s"; // f converts float to string
            
            if(hatchTimer <= 0.0f){
                hatchIt = true;
            }

        }
        else if(hatchTimer <= 0.0f || hatchIt == true) // we dont count anymore
        {
            
            timerText.text = "Hatching Now!";
            hatchTimer = 0.0f;

        }

        
    }





}
