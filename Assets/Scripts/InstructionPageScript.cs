using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionPageScript : MonoBehaviour
{
    [SerializeField]private GameObject page1;
    [SerializeField]private GameObject page2;
    [SerializeField]private GameObject page3;
    [SerializeField]private GameObject page4;
    [SerializeField]private GameObject page5;

    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
        page3.SetActive(false);
        page4.SetActive(false);
        page5.SetActive(false);
    }

    public void NextPage()
    {
        if(page1.activeInHierarchy)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            
        }

        else if(page2.activeInHierarchy)
        {
            page2.SetActive(false);
            page3.SetActive(true);
        }

        else if(page3.activeInHierarchy)
        {
            page3.SetActive(false);
            page4.SetActive(true);
        }

        else if(page4.activeInHierarchy)
        {
            page4.SetActive(false);
            page5.SetActive(true);
        }
    }

    public void BackPage()
    {
        if(page5.activeInHierarchy)
        {
            page5.SetActive(false);
            page4.SetActive(true);
        }
        else if (page4.activeInHierarchy)
        {
            page4.SetActive(false);
            page3.SetActive(true);
        }
        else if (page3.activeInHierarchy)
        {
            page3.SetActive(false);
            page2.SetActive(true);
        }
        else if (page2.activeInHierarchy)
        {
            page2.SetActive(false);
            page1.SetActive(true);
        }
        else if (page1.activeInHierarchy)
        {
            SceneManager.LoadScene(0);
        }
    }


}
