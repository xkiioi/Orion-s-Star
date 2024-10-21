using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void start()
    {
        //Load the sect01 scene
        SceneManager.LoadScene("Sect_01");
    }

    public void levels()
    {
        SceneManager.LoadScene("Levels");
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
