using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hatchigotchi : MonoBehaviour
{

    public string name; 
    public int currentScene; 


    public int bondingMeter; 

    
    public int hungerMeter;
    public int happinessMeter;
    public int playfulMeter;
    public int sleepinessMeter;

    public void SaveHatchigotchi()
    {
        if(!SceneHandler.eggScene)
        {
            //name = NamingStageScript.theName.text; 

            bondingMeter = ObjectsHandler.bondingMeter;

            hungerMeter = NeedsAndActionScript.hungerMeter; 
            happinessMeter = NeedsAndActionScript.happinessMeter;
            playfulMeter = NeedsAndActionScript.playfulMeter;
            sleepinessMeter = NeedsAndActionScript.sleepinessMeter;
        }
        currentScene = SceneHandler.currentScene;
        SaveSystem.SaveHatchigotchi(this);
    }

    
    public void LoadHatchigotchi()
    {
        try
        {
            
            HatchigotchiData data = SaveSystem.LoadHatchigotchi();

            if(!SceneHandler.eggScene)
            {
                name = data.name; 
                print("name: " + name);

                bondingMeter = data.bondingMeter;
                

                hungerMeter = data.hungerMeter;  
                happinessMeter = data.happinessMeter;
                playfulMeter = data.playfulMeter;
                //sleepinessMeter = data.sleepinessMeter;

            }
            
            // Load the scene
            currentScene = data.currentScene;
            SceneManager.LoadScene(currentScene);
            
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
            throw ex;
        }
    }


}


