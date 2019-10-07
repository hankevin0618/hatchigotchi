using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hatchigotchi : MonoBehaviour
{
    public int age = 10;
    public string name;
    public int currentScene;

    public int hungerMeter;
    public int happinessMeter;
    public int playfulMeter;
    public int sleepinessMeter;


    

    public void SaveHatchigotchi()
    {
        if(!SceneHandler.eggScene)
        {
        name = NamingStageScript.theName.text;
        
        // age = 10;
        // hungerMeter = NeedsAndActionScript.hungerMeter;
        // happinessMeter = NeedsAndActionScript.happinessMeter;
        // playfulMeter = NeedsAndActionScript.playfulMeter;
        // sleepinessMeter = NeedsAndActionScript.sleepinessMeter;
        }
        currentScene = SceneHandler.currentScene;
        

        SaveSystem.SaveHatchigotchi(this);
    }

    
    public void LoadHatchigotchi()
    {
        try
        {
            
            HatchigotchiData data = SaveSystem.LoadHatchigotchi();

            // 이름기억완료

            if(!SceneHandler.eggScene)
            {
                
                name = data.name; 
                print("name: " + name);
                
                
                

                
                
                
                // age = data.age;
                // NeedsAndActionScript.hungerMeter = data.hungerMeter;
                // happinessMeter = data.happinessMeter;
                // playfulMeter = data.playfulMeter;
                // sleepinessMeter = data.sleepinessMeter;                
            }

            currentScene = data.currentScene;
            print("Load Scene: " +currentScene);
            SceneManager.LoadScene(currentScene);
            
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
            throw ex;
        }
    }


}


