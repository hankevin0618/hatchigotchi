using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HatchingOut : MonoBehaviour
{

    private Animator animator;
    private float freezeTime = 15f; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!HatchingTimer.hatchIt)
        {
            animator.SetInteger("AnimState", 0);
        }
        else
        {
            animator.SetInteger("AnimState", 1);
            freezeTime -= Time.deltaTime;
            if(freezeTime <= 0.0f)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
            }
            
        }

    }
}
