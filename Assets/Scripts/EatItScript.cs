using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItScript : MonoBehaviour
{
    public static bool turnEat;
    public static Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        turnEat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(turnEat)
        {
            animator.SetInteger("MeatAnimState", 1);
            
        }
    }
}
