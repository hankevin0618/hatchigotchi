using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NamingStageScript : MonoBehaviour
{

    private InputField theInput;

    public static Text theName; 
    
    
    

    void Start()
    {
        theInput = GetComponent<InputField>();
        
    }
    public void ToNextScene()
    {
        SceneHandler.currentScene = 4;
        SceneHandler.eggScene = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void GetTheName()
    {
        theName = theInput.textComponent;

    }
}
