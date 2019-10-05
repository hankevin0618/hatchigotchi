using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hatchigotchi : MonoBehaviour
{
    public int age = 10;
    public string name;
    public static int currentScene = 2;
    public Text nameGetter;

    public int hungerMeter;
    public int happinessMeter;
    public int playfulMeter;
    public int sleepinessMeter;



    
    public void SaveHatchigotchi()
    {
        name = nameGetter.text;
        
        age = 10;
        hungerMeter = NeedsAndActionScript.hungerMeter;
        happinessMeter = NeedsAndActionScript.happinessMeter;
        playfulMeter = NeedsAndActionScript.playfulMeter;
        sleepinessMeter = NeedsAndActionScript.sleepinessMeter;
        
        SaveSystem.SaveHatchigotchi(this);
    }
    public void LoadHatchigotchi()
    {
        SceneManager.LoadScene(currentScene);
        HatchigotchiData data = SaveSystem.LoadHatchigotchi();

        // 저장이 다 되는데 로드도 되는데 씬 들어가서 업데이트가 안됨.
        // 덮어씌워지질 않나봄
        // 껐다 키면 이름도 지워짐. 그러나 데이터는 남아있음
        name = data.name; // 이거부터 구현하면 될듯.
        age = data.age;
        NeedsAndActionScript.hungerMeter = data.hungerMeter;
        happinessMeter = data.happinessMeter;
        playfulMeter = data.playfulMeter;
        sleepinessMeter = data.sleepinessMeter;

        

        
    }
}


