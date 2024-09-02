using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName;
    public void SceneChange()
    {
        //Load a scene
        SceneManager.LoadScene(sceneName);
    }
}
