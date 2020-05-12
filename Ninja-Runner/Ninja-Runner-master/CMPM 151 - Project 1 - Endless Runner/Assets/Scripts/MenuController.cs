using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    //Loads a specific scene based on the scene name given
    public void LoadScene(string SceneName)
    {
        //access SceneManager to be able to load the specified scene
        SceneManager.LoadScene(SceneName);
    }
}
