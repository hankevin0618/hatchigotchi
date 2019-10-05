using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HatchingTimer : MonoBehaviour
{
    // make visible in the inspector
    [SerializeField] private Text timerText;

    private Animator animator;

    public static bool hatchIt = false;
    
    public bool newUser;

    

    void Start() {
        if(newUser) // from GetTheCode.cs
        {
            TimeMaster.instance.SaveDate();
            GetTheCode.hatchTimer = 3000;
        } 

         GetTheCode.hatchTimer -= TimeMaster.instance.CheckDate();
        
        

    }


    void Update() 
    {
        print(GetTheCode.hatchTimer);
        if(GetTheCode.hatchTimer >= 0.0f && !hatchIt)
        {
            //timer -= TimeMaster.instance.CheckDate();
            GetTheCode.hatchTimer -= Time.deltaTime;
            
            timerText.text = "Hatching in: " + GetTheCode.hatchTimer.ToString("0") + "s"; // f converts float to string
            
            if(GetTheCode.hatchTimer <= 0.0f){
                hatchIt = true;
            }

        }
        else if(GetTheCode.hatchTimer <= 0.0f || hatchIt == true) // we dont count anymore
        {
            
            timerText.text = "Hatching Now!";
            GetTheCode.hatchTimer = 0.0f;

        }

        
    }





}
