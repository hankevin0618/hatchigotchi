using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsAndActionScript : MonoBehaviour
{


    // 잠자기
    // 혼나야하는 상황?
    // 저장하기
    // 유저와의 본딩? prefab으로 선물이나 행동을 얻을 수 있음
    // expression - unhappy and stressed 차이 조정.
    // sleep timer를 좀 길게 조정해놓고, 다른 액션들로 감소시키기
    // 자는동안 다른 액션들 제한하기

    public static Animator HGAnimator;

    // Hunger variables
    private static int hungerMeter;
    private bool hungry = false;

    // Happiness variables
    public static int happinessMeter;
    public static bool happy = true;


    // Playful variables
    public static int playfulMeter;
    private bool bored = false;


    // Sleepness variables
    public static int sleepinessMeter;
    private bool sleepy = false;
    private bool inSleep = false;

    private int sleepAmount;

    // General variables
    private int moderateValue = 50;
    private int maxValue = 100;


    // Game objects
    private string meatName = "meat(Clone)";


    // Timer variables
    private float animTimer = 5f;
    private float hungerTimer = 5f;
    private float happinessTimer = 5f;
    private float playfulTimer = 5f;
    private float sleepinessTimer = 350; // 5 mins
    private float inSleepTimer = 10;






    // Start is called before the first frame update
    void Start()
    {
        
        HGAnimator = GetComponent<Animator>();
        hungerMeter = moderateValue;
        happinessMeter = moderateValue;
        playfulMeter = moderateValue;
        sleepinessMeter = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        AnimHandler();
        HungerHandler();
        HappinessHandler();
        PlayfulHandler();
        SleepHandler();
        
        // in sleep mode
        SleepMode();

    }


    void AnimHandler()
    {
        animTimer -= Time.deltaTime;
        if(animTimer <= 0.0f)
        {
            int AnimState = Random.Range(0,2);

            switch(AnimState)

            {
                // happy or unhappy
                case 1:
                Debug.Log("it is 1");
                Expression();
                animTimer = 10f;
                break;

                // sleep
                case 0:
                Debug.Log("it is 0");
                Sleep();
                
                break;


                default:
                Debug.Log("it is default");
                HGAnimator.SetInteger("HGAnimState", 0);
                animTimer = 10f;
                break;


            }

            
        }
    }

    void HungerHandler()
    {
        int hungryPoint = 30;
        int fullPoint = 80;
        hungerTimer -= Time.deltaTime;

        if(hungry)
        {
            Eat();
        }

        if(hungerMeter < 0)
        {
            hungerMeter = 0;
        }

        if(hungerTimer <= 0.0f)
        {
            hungerMeter--;
            hungerTimer = 5f;
            Debug.Log("current hunger meter is: " + hungerMeter);
        }

        if(hungerMeter <= hungryPoint)
        {
            hungry = true;
            
        }
        else if(hungerMeter > hungryPoint && hungerMeter <= fullPoint)
        {  
            hungry = true;

        }
        else if(hungerMeter > fullPoint)
        {
            hungry = false;
            
        }
        if(hungerMeter > maxValue)
        {
            hungerMeter = maxValue;
        }


    }


    
    void Expression() {        
        
        if(happy)
        {
            HGAnimator.SetInteger("HGAnimState", 1);
        }
        else if(!happy && bored)
        {
            HGAnimator.SetInteger("HGAnimState", 4);
        }
        else if(!happy && hungry)
        {
            HGAnimator.SetInteger("HGAnimState", 4);
        }
        else if(!happy)
        {
            HGAnimator.SetInteger("HGAnimState", 2);
            ObjectsHandler.poopTimer -= 1;
        }


    }

    void Eat() {

        try
        {
            if(hungry && GameObject.Find(meatName) && !inSleep)
            {   
                
                if(!EatItScript.turnEat)
                {
                    hungerMeter += 10;
                    happinessMeter += 10;
                    ObjectsHandler.poopTimer -= 1;
                     Debug.Log("Current Poop Timer is: " + ObjectsHandler.poopTimer);
                }
                
                EatItScript.turnEat = true;
                
               

            }
        }
        catch(System.NullReferenceException ex)
        {
            Debug.Log(ex);
        }

        
    }


    void HappinessHandler()
    {

        int unhappyPoint = 40;
        int happyPoint = 80;
        happinessTimer -= Time.deltaTime;
        
        if(happinessMeter < 0)
        {
            happinessMeter = 0;
        }

        if(happinessTimer <= 0.0f)
        {
            happinessMeter--;
            happinessTimer = 5f;
            Debug.Log("current happiness meter is: " + happinessMeter);
        }

        if(happinessMeter < unhappyPoint)
        {
            happy = false;
        }
        else if(happinessMeter > unhappyPoint && happinessMeter < happyPoint)
        {
            happy = true;
        }
        else if(happinessMeter > happyPoint)
        {
            happy = true;
            
        }
        if(happinessMeter > maxValue)
        {
            happinessMeter = maxValue;
        }

        
    }

    void PlayfulHandler()
    {
        int boredPoint = 30;
        int playfulPoint = 80;
        playfulTimer -= Time.deltaTime;
        
        if(playfulMeter < 0)
        {
            playfulMeter = 0;
        }

        if(playfulTimer <= 0.0f)
        {
            playfulMeter--;
            playfulTimer = 5f;
            Debug.Log("current playful meter is: " + playfulMeter);
        }

        if(playfulMeter < boredPoint)
        {
            bored = true;
            
        }
        else if(playfulMeter > boredPoint && playfulMeter < playfulPoint)
        {
            bored = false;
        }
        else if(playfulMeter > boredPoint)
        {
            bored = false;
            
        }
        if(playfulMeter > maxValue)
        {
            playfulMeter = maxValue;
        }
    }

    void SleepHandler()
    {
        int sleepyPoint = 30;
        int awakePoint = 80;
        sleepinessTimer -= Time.deltaTime;
        
        if(sleepinessMeter < 0)
        {
            sleepinessMeter = 0;
        }

        if(sleepinessTimer <= 0.0f)
        {
            sleepinessMeter--;
            sleepinessTimer = 350f; // 5 mins
            Debug.Log("current sleepiness meter is: " + sleepinessMeter);
        }

        if(sleepinessMeter < sleepyPoint)
        {
            sleepy = true;
            
        }
        else if(sleepinessMeter > sleepyPoint && sleepinessMeter < awakePoint)
        {
            sleepy = false;
        }
        else if(sleepinessMeter > sleepyPoint)
        {
            sleepy = false;
            
        }

        if(sleepinessMeter > maxValue)
        {
            sleepinessMeter = maxValue;
        }
    }

    void Sleep()
    {
        
        // if sleepy, sleep & stop other actions and needs meters
        if(sleepy)
        {
            sleepAmount = Random.Range(60,120); //  give about a few hours
            Debug.Log("Sleep Amount is: " + sleepAmount);
            animTimer += sleepAmount;
            Debug.Log("animTimer: " + animTimer);
            HGAnimator.SetInteger("HGAnimState", 6);

            // stop all the timers and sleep mode on.
            ObjectsHandler.poopTimer += sleepAmount;
            playfulTimer += sleepAmount;
            hungerTimer += sleepAmount;
            sleepinessTimer += sleepAmount;
            happinessTimer += sleepAmount;

            inSleep = true;
                 
        }
        else
        {
            HGAnimator.SetInteger("HGAnimState", 0);
            animTimer = 10f;
            inSleep = false;
        }

        // else, default
    }

    void SleepMode()
    {


        if(inSleep)
        {
            inSleepTimer -= Time.deltaTime;
            if(inSleepTimer <= 0.0f)
            {
                Debug.Log("animTimer: " + animTimer);
                happinessMeter += 1;
                Debug.Log("happinessMeter: " + happinessMeter);
                sleepinessMeter += 1;
                Debug.Log("sleepinessMeter: " + sleepinessMeter);
                inSleepTimer = 5f;
            }
        } 
                 

        
    }
    

}
