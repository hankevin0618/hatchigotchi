using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchingTest : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (animator.GetInteger("AnimState").Equals(0))
            {
                animator.SetInteger("AnimState", 1);
            }
            else
            {
                animator.SetInteger("AnimState", 0);
            }

        }

    }
}
