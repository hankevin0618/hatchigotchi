using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HomeScreen : MonoBehaviour
{
    public void BackToHomeScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void ToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
