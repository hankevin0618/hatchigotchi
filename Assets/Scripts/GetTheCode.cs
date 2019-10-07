﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GetTheCode : MonoBehaviour
{
    private InputField theCodeInput;
    private Color greenColor = new Color(0, 1, 0);
    private Color redColor = new Color(1, 0, 0);
    private Color blackColor = new Color(0,0,0);
    
    private string validCode = "AwesomeHatchigotchi1234";
    private string devValidCode = "1";

    public static bool newUser = false;
    
    // Start is called before the first frame update
    void Start()
    {
        theCodeInput = GetComponent<InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(theCodeInput.text == "")
        {
            theCodeInput.textComponent.color = blackColor;    
        }
        
    }

    public void Verify()
    {

        if(theCodeInput.text == validCode || theCodeInput.text == devValidCode)
        {
            // next scene
            HatchigotchiData.currentScene = 2;
            theCodeInput.textComponent.color = greenColor;
            newUser = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        } else if(theCodeInput.text != validCode)
        {
            theCodeInput.textComponent.color = redColor;
        }

    }
}
