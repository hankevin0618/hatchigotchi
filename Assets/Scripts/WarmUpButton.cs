using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmUpButton : MonoBehaviour
{
    public SpriteRenderer theEggRenderer; //what are we rendering? The egg
    private Rigidbody2D theEggBody2D;

    HatchingTimer hatchingTimer;

    private Color warmColor;
    private Color defalutColor;
    private Color coolColor;



    // Start is called before the first frame update
    void Start()
    {
         theEggRenderer = GetComponent<SpriteRenderer>();
         theEggBody2D = GetComponent<Rigidbody2D>();
         hatchingTimer = GetComponent<HatchingTimer>(); // no good


         warmColor = new Color(10,0.5f,0.5f);
         defalutColor = theEggRenderer.color;
         coolColor = new Color(0,0,255, 0.5f);
        

        
    }
    public void WarmUp(){
       
        Debug.Log("Warming Up");
        

        theEggRenderer.color = warmColor;

        Debug.Log(theEggRenderer.color);
        Debug.Log(defalutColor);
        
        

    }

    public void CoolDown() {
        Debug.Log("Cooling Down");

        theEggRenderer.color = defalutColor;

        Debug.Log(theEggRenderer.color);

        
    }


    // Update is called once per frame
    void Update()
    {
        // if(hatchingTimer.timer < 2995f){
        //   theEggRenderer.color = warmColor;          
        // }
        
    }
}