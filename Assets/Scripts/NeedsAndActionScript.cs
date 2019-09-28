using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedsAndActionScript : MonoBehaviour
{
    // 확률에 따라 애니메이션이 바꾸는거까지 구현완료
    // 이거 다음은 이제 기분을 만들어서 기분에 따라 애니메이션의
    // 범위가 정해지는 것과,
    // 배가 고프면 음식을 먹고 안고프면 안먹고, 음식을 먹으면
    // 응가싸는 시간이 줄어드는 걸 구현.
    // 혼냈을때 약간의 변화도 필요.
    private Animator animator;

    private static int hungerMeter;
    private bool hungry = false;

    private int happinessMeter;
    private bool happy = true;

    private int borednessMeter;
    private bool bored = false;



    private int moderateValue = 50;
    private int maxValue = 100;


    // Game objects
    private string meatName = "meat(Clone)";

    private float animTimer = 5f;
    private float hungerTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hungerMeter = moderateValue;
        happinessMeter = moderateValue;
        borednessMeter = moderateValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        AnimHandler();
        HungerHandler();

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
                Debug.Log("It is 2 -- eat");
                animator.SetInteger("HGAnimState", 0);
                break;

                
                // Happy Dance
                case 1:
                HappyAction();
                break;

                case 0:
                Debug.Log("It is 0");
                animator.SetInteger("HGAnimState", 0);
                break;


                default:
                animator.SetInteger("HGAnimState", 0);
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
            animator.SetInteger("HGAnimState", 1);
        }
        else if(!happy)
        {
            // something bad
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
                }
                
                EatItScript.turnEat = true;
                ObjectsHandler.poopTimer -= 1;

            }
        }
        catch(System.NullReferenceException ex)
        {
            Debug.Log(ex);
        }

        
    }
}
