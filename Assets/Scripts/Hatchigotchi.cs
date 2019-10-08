using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hatchigotchi : MonoBehaviour
{

    // Bonding meter 글로벌화
    // sleeping meter 글로벌화
    // Bonding card 핥기
    // Save 버튼 지우기

    public int age = 10; // aging should start 
    public string name; // working
    public int currentScene; // working


    public int bondingMeter; // 플러스 10 마이너스 10에 따라서 임의로 본딩카드를 prefab으로 주자

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


