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

    private int hungerMeter;
    private int happinessMeter;
    private int borednessMeter;
    private int maxValue = 100;

    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hungerMeter = maxValue;
        happinessMeter = maxValue;
        borednessMeter = maxValue;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;
        if(timer <= 0.0f)
        {
            int x = Random.Range(0,3);

            switch(x)

            {

                case 2:
                Debug.Log("It is 2");
                break;

                
                // Happy Dance
                case 1:
                Debug.Log("It is 1");
                animator.SetInteger("HGAnimState", 1);
                break;

                case 0:
                Debug.Log("It is 0");
                animator.SetInteger("HGAnimState", 0);
                break;


                default:
                animator.SetInteger("HGAnimState", 0);
                break;


            }

            timer = 10f;
        }
        
        
    }

    void HappyAction() {
        float freezeTime = 5;
        
        Debug.Log("DanceTime!");
        
        freezeTime -= Time.deltaTime;
    }
}
