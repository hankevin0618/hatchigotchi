using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetTheName : MonoBehaviour
{
    public static Text hatchigotchiName;
    private Text inputName;

    private HatchigotchiData data;

    



    // Start is called before the first frame update
    void Start()
    {
        hatchigotchiName = GetComponent<Text>();
        inputName = GetComponent<Text>();
        data = SaveSystem.LoadHatchigotchi();


        inputName = NamingStageScript.theName;
        
        LoadName();
        try{

            hatchigotchiName.text = inputName.text;
            
        }
        catch(System.Exception ex)
        {
            Debug.Log(ex);
        }
        
    }

    public void LoadName()
    {
        
        if(data.name.Length > 0)
        {
            hatchigotchiName.text = data.name;  
        } else
        {
            Debug.Log("No name loaded");
            hatchigotchiName.text = "Empty";
        }
            
        

    }

    
}
