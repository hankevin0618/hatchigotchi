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
            data.name = hatchigotchiName.text;
            
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
            
            try
            {
                hatchigotchiName.text = data.name;  
            }
            catch (System.Exception ex)
            {
                
                Debug.Log(ex);
            }
            
        } else
        {
            try
            {
                hatchigotchiName.text = "Empty";
            }
            catch (System.Exception ex)
            {
                Debug.Log(ex);
                
            }
                        
        }

        // print("GetTheName name: " + hatchigotchiName.text);
            
        

    }

    
}
