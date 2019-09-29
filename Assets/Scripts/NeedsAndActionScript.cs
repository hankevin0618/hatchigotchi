using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsAndActionScript : MonoBehaviour
{
    // 행복미터기 -- 완
    // 잠자기와 자는 모습
    // 혼날떄 슬픈 얼굴
    // 혼나야하는 상황?
    // 저장하기
    // 에그 코드 인식하기 
    public static Animator HGAnimator;

    private static int hungerMeter;
    private bool hungry = false;

    public static int happinessMeter;
    public static bool happy = true;

    private int borednessMeter;
    private bool bored = false;



    private int moderateValue = 50;
    private int maxValue = 100;


    // Game objects
    private string meatName = "meat(Clone)";

    private float animTimer = 5f;
    private float hungerTimer = 5f;
    private float happinessTimer = 5f;






    // Start is called before the first frame update
    void Start()
    {
        
        HGAnimator = GetComponent<Animator>();
        hungerMeter = moderateValue;
        happinessMeter = moderateValue;
        borednessMeter = moderateValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        AnimHandler();
        HungerHandler();
        HappinessHandler();

    }


    void AnimHandler()
    {
        animTimer -= Time.deltaTime;
        if(animTimer <= 0.0f)
        {
            int AnimState = Random.Range(0,3);

            switch(AnimState)

            {

                // Scold & fear / angry
                case 2:
                HGAnimator.SetInteger("HGAnimState", 0);
                break;

                
                // happy or unhappy
                case 1:
                HappyAction();
                
                break;

                case 0:
                Debug.Log("It is 0");
                HGAnimator.SetInteger("HGAnimState", 0);
                break;


                default:
                HGAnimator.SetInteger("HGAnimState", 0);
                break;


            }

            animTimer = 10f;
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

        if(hungerTimer <= 0.0f)
        {
            hungerMeter--;
            hungerTimer = 5f;
            Debug.Log("current hunger meter is: " + hungerMeter);
        }

        if(hungerMeter <= hungryPoint)
        {
            hungry = true;
            // and give angry point
        }
        else if(hungerMeter > hungryPoint && hungerMeter <= fullPoint)
        {  // just hungry
            hungry = true;

        }
        else if(hungerMeter > fullPoint)
        {
            hungry = false;
            // give some happiness
        }
        else if(hungerMeter > maxValue)
        {
            hungerMeter = maxValue;
        }

    }


    
    void HappyAction() {        
        
        if(happy)
        {
            HGAnimator.SetInteger("HGAnimState", 1);
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
            if(hungry && GameObject.Find(meatName))
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

        if(happinessTimer <= 0.0f)
        {
            happinessMeter--;
            happinessTimer = 5f;
            Debug.Log("current happiness meter is: " + happinessMeter);
        }

        if(happinessMeter < unhappyPoint)
        {
            // unhappy anim
            happy = false;
        }
        else if(happinessMeter > unhappyPoint && happinessMeter < happyPoint)
        {
            happy = true;
        }
        else if(happinessMeter > happyPoint)
        {
            happy = true;
            borednessMeter += 1;
            
            // very happy animation
        }
        else if(happinessMeter > maxValue)
        {
            happinessMeter = maxValue;
        } 
        
    }

    

}
