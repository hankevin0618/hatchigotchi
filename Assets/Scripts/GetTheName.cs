using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTheName : MonoBehaviour
{
    [SerializeField] private Text hatchigotchiName;
    private Text inputName;



    // Start is called before the first frame update
    void Start()
    {
        hatchigotchiName = GetComponent<Text>();
        inputName = GetComponent<Text>();
        inputName = NamingStageScript.theName;
        hatchigotchiName.text = inputName.text;
    }

    void PushName(){
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
