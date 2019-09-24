using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{

    public ObjectsHandler meatHandler;
    public ObjectsHandler pooHandler;

    // Meats variables
    public int maxMeats = 3;

    private int numOfMeats = 0;
    private string meatName = "meat(Clone)";


    // Poops variables
    
    private int maxPoos = 6;
    private int numOfPoos = 0;
    private string pooName = "poo(Clone)";

    private float minXPos = 0f;
    private float maxXPos = 0f;
    private float minYPos = 0f;
    private float maxYPos = 0f;


    private SpriteRenderer renderer2D;
    private Rigidbody2D body2d;

    public Animator bubbles;



    private float time = 0f;
    

    // Start is called before the first frame update
    void Start()
    {
        renderer2D = GetComponent<SpriteRenderer>();
        body2d = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // time += Time.deltaTime;


        
    }

    public void CleanUp() {

        if(numOfMeats > 0){
            
            for(int i = 0; i < numOfMeats; i++)
            {
                
                DestroyImmediate(GameObject.Find(meatName));
                DestroyImmediate(GameObject.Find(pooName));
                //Debug.Log("removed meat");
            }
            
            numOfMeats = 0;
            //Debug.Log("0 meats");
            
        }


        
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

    public void Poop() {

        /*
        Location limitations
        
        Transform - Position
        x: -2.7 ~ 2.7
        y: -1.689 ~ -4.541
        
         */
        if(numOfPoos < maxPoos){
            numOfPoos++;
            Vector3 pooPosition = new Vector3(0, 0, 0);
            var clone = Instantiate(pooHandler, pooPosition, Quaternion.identity);
            // 밑에 링크타고 랜덤 적용해서 응가가 나타날 수 있게 하는거부터 시작하렴
            //https://docs.unity3d.com/ScriptReference/Random.Range.html
        } else{
            //something bad thing happens
        }
    }

}
