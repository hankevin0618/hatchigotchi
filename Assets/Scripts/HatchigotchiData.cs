using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HatchigotchiData
{

    public string name;
    public int currentScene;

    public int bondingMeter;

    public int hungerMeter;
    public int happinessMeter;
    public int playfulMeter;
    public int sleepinessMeter;
    


    public HatchigotchiData(Hatchigotchi hatchigotchi)
    {
        name = hatchigotchi.name;
        currentScene = hatchigotchi.currentScene;

        bondingMeter = hatchigotchi.bondingMeter; // focus

        hungerMeter = hatchigotchi.hungerMeter;
        happinessMeter = hatchigotchi.happinessMeter;
        playfulMeter = hatchigotchi.playfulMeter;
        sleepinessMeter = hatchigotchi.sleepinessMeter;
        

        
    }
}
