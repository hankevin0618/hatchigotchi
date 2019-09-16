using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsHandler : MonoBehaviour
{

    public ObjectsHandler objectsHandler;
    public int maxMeats = 3;

    private int numOfMeats = 0;
    private string meatName = "meat(Clone)";





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

        
        

        bubbles.SetInteger("CleanAnimState", 1);


        if(numOfMeats > 0){
            
            for(int i = 0; i < numOfMeats; i++)
            {
                
                DestroyImmediate(GameObject.Find(meatName));
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
            var clone = Instantiate(objectsHandler, t.position, Quaternion.identity);
            var body2d = clone.GetComponent<Rigidbody2D>();
            body2d.AddForce(Vector3.right * Random.Range(-100, 100));     
        }
        
    }

}
