using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HatchigotchiData
{
    // 필요한거
    // 이름, 나이, 응가의 갯수와 meat의 갯수? 하이라키 저장 가능?
    // 미터들
    // maybe 관계도 later
    public string name;
    public int age;
    public int numOfPoos;
    public int numOfMeats;
    

    public int currentScene;
    

    public int hungerMeter; 
    public int happinessMeter; 
    public int playfulMeter; 
    public int sleepinessMeter;




    public HatchigotchiData(Hatchigotchi hatchigotchi)
    {
        name = hatchigotchi.name;
        age = hatchigotchi.age;
        hungerMeter = hatchigotchi.hungerMeter;
        happinessMeter = hatchigotchi.happinessMeter;
        playfulMeter = hatchigotchi.playfulMeter;
        sleepinessMeter = hatchigotchi.sleepinessMeter;
        currentScene = hatchigotchi.currentScene;
        

        
    }
}
