using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimer : MonoBehaviour
{
    //Test timer
    public float timer;



    // Start is called before the first frame update
    void Start()
    {

        //Init timer to our starting amount
        timer = 300;

        // Update timer with real time passed
        timer -= TimeMaster.instance.CheckDate();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update our timer each frame
        timer -= Time.deltaTime;
    }

    void onGUI()
    {
        if(GUI.Button(new Rect(10,10,100,50), "Save Time"))
        {
            ResetClock();
        }
        if(GUI.Button(new Rect(10,150,100,50), "Check Time"))
        {
            print (60 - TimeMaster.instance.CheckDate() + " in real seconds have passed");
        }

        GUI.Label(new Rect(10,150,100,50), timer.ToString());
    }


    void ResetClock() 
    {
        TimeMaster.instance.SaveDate();
        timer = 300;
        timer -= TimeMaster.instance.CheckDate();
    }
}
