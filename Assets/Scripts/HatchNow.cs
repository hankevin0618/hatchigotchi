using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HatchNow : MonoBehaviour
{


    HatchingTimer hatchIt;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // hatchIt = GetComponent<HatchingTimer>();

        
    }

    void Update() {
        
    }

    public void HatchITNow() {
        HatchingTimer.hatchIt = true;
    }

}
