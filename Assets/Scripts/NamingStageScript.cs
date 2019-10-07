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
        HatchigotchiData.currentScene = 4;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void GetTheName()
    {
        theName = theInput.textComponent;

        
        
    }
}
