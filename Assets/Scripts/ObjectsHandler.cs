using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{

    public ObjectsHandler meatHandler;
    public ObjectsHandler pooHandler;

    // Meats variables
    private int maxMeats = 3;

    private int numOfMeats = 0;
    private string meatName = "meat(Clone)";


    // Poops variables
    
    private int maxPoos = 6;
    private int numOfPoos = 0;
    private string pooName = "poo(Clone)";

    private float minXPos = -2.7f;
    private float maxXPos =  2.7f;
    private float minYPos = -1.689f;
    private float maxYPos = -4.541f;


    private SpriteRenderer renderer2D;
    private Rigidbody2D body2d;

    public static float poopTimer = 60f;
    

    // Start is called before the first frame update
    void Start()
    {
        renderer2D = GetComponent<SpriteRenderer>();
        body2d = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {  
        poopTimer -= Time.deltaTime;
        
        if(poopTimer <= 0.0f){ 
            Poop(); 
            poopTimer = 350f; // 5 mins
        }
    }

    public void CleanUp() {

        // if(numOfMeats > 0){
        //     for(int i = 0; i < numOfMeats; i++)
        //     {  
        //         DestroyImmediate(GameObject.Find(meatName));
        //     }
        //     numOfMeats = 0;
        // }
        
        
        if(numOfMeats > 0)
        {
            numOfMeats--;
            DestroyImmediate(GameObject.Find(meatName));
        }

        if(numOfPoos > 0)
        {
            numOfPoos--;
            DestroyImmediate(GameObject.Find(pooName));
        }
        DestroyImmediate(GameObject.Find(pooName));
        


        
    }

    public void Feed() {
        if(numOfMeats < maxMeats){
            numOfMeats++;
            var t = transform;
            t.TransformVector(100, 0, 0);
            var clone = Instantiate(meatHandler, t.position, Quaternion.identity);
            var body2d = clone.GetComponent<Rigidbody2D>();
            body2d.AddForce(Vector3.right * Random.Range(-100, 100));     
        }
        
    }

    void Poop() {

        /*
        Location limitations
        
        Transform - Position
        x: -2.7 ~ 2.7
        y: -1.689 ~ -4.541
        
         */

        if(numOfPoos < maxPoos){
            numOfPoos++;
            try{
                
                Vector3 pooPosition = new Vector3(Random.Range(minXPos, maxXPos), Random.Range(minYPos, maxYPos), 0);
                var clone = Instantiate(pooHandler, pooPosition, Quaternion.identity);
            }
            catch(System.Exception ex)
            {
                Debug.Log(ex);
            }
            
            
        } else{
            //something bad thing happens
        }
    }

        public void Scold() {
        poopTimer -= 10;
        
    }

}
