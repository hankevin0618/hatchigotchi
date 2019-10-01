using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetTheName : MonoBehaviour
{
    public static Text hatchigotchiName;
    private Text inputName;



    // Start is called before the first frame update
    void Start()
    {
        hatchigotchiName = GetComponent<Text>();
        inputName = GetComponent<Text>();
        inputName = NamingStageScript.theName;

        try{
            hatchigotchiName.text = inputName.text;
        }
        catch(System.Exception ex)
        {
            Debug.Log(ex);
        }

        
    }

    void PushName(){
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
