using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{

    public ObjectsHandler meatHandler;
    public ObjectsHandler pooHandler;
    public ObjectsHandler stoneCardHandler;
    public ObjectsHandler hideCardHandler;
    public ObjectsHandler biteCardHandler;

    // Bonding Variables
    public static int bondingMeter;
    private int maxBonding = 25; // make it 25
    private int minBonding = -25;
    private float bondingTimer = 10;
    Vector3 cardPos;
    private string stoneName = "stone_bondingcard(Clone)";
    private string hideName = "hide_bondingcard(Clone)";
    private string biteName = "bite_bondingcard(Clone)";
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
        SceneHandler.currentScene = 4;
        renderer2D = GetComponent<SpriteRenderer>();
        body2d = GetComponent<Rigidbody2D>();
        cardPos = new Vector3(0,0,0);

      
    }

    // Update is called once per frame
    void Update()
    {  
        poopTimer -= Time.deltaTime;
        
        if(poopTimer <= 0.0f){ 
            Poop(); 
            poopTimer = 350f; // 5 mins
        }

        BondingCard();
    }

    public void CleanUp() {
        
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

        public void Scold() 
    {
        NeedsAndActionScript.wakeUp = true;
        poopTimer -= 3;
        NeedsAndActionScript.happinessMeter --;
        NeedsAndActionScript.HGAnimator.SetInteger("HGAnimState", 3);
    }

    public void Play()
    {
        if(!NeedsAndActionScript.inSleep)
        {
            NeedsAndActionScript.happinessMeter += 3;
            NeedsAndActionScript.playfulMeter += 7;
            NeedsAndActionScript.HGAnimator.SetInteger("HGAnimState", 5);
            NeedsAndActionScript.sleepinessMeter -= 1;
        }
    
    }


    void BondingCard()
    {
        
        bondingTimer -= Time.deltaTime;
        if(bondingTimer <= 0.0f)
        {
            
            if(NeedsAndActionScript.happy)
            {
                bondingMeter++;
                print("Bonding Increased! =>" + bondingMeter);
                if(bondingMeter == maxBonding)
                {
                    if(!GameObject.Find(stoneName))
                    {
                        var stone = Instantiate(stoneCardHandler, cardPos, Quaternion.identity);
                    }
                    
                    bondingMeter = 0;
                }
            }
            else if(!NeedsAndActionScript.happy)
            {
                int cardState = Random.Range(0,2);
                bondingMeter--;
                print("Bonding Decreased! =>" + bondingMeter);
                if(bondingMeter == minBonding)
                {
                    switch(cardState)
                    {
                        // Bite
                        case 1:
                            if(!GameObject.Find(biteName))
                            {
                                var bite = Instantiate(biteCardHandler, cardPos, Quaternion.identity);
                            }
                            break;

                        // Hide
                        case 0:
                            if(!GameObject.Find(hideName))
                            {
                                var hide = Instantiate(hideCardHandler, cardPos, Quaternion.identity);
                            }
                            break;
                        
                        default:
                            break;
                    }
                    
                    bondingMeter = 0; 
                }
            }


            bondingTimer = 10;
        }

    }

    public void CloseCard() {
        try
        {
            DestroyImmediate(this.gameObject);
            
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
            throw;
        }
       
    }


}
