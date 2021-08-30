using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject levelLoader;
    
    // Start is called before the first frame update
    public void ChangeToMenu()
    {
         levelLoader.GetComponent<LevelLoaderScript>().LoadNextScene("Menu");

    }

    public void ChangeToRegister()
    {
        levelLoader.GetComponent<LevelLoaderScript>().LoadNextScene("Registration");
    }
}
