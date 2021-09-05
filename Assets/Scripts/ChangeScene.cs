using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static ChangeScene instance;
    public GameObject loadingScreen;

    private List<AsyncOperation> sceneLoading = new List<AsyncOperation>();

    private void Awake()
    {
        instance = this;
        SceneManager.LoadSceneAsync((int)SceneList.MENU, LoadSceneMode.Additive);
    }

    // Start is called before the first frame update
    public void ChangeToMenu()
    {
         // levelLoader.GetComponent<LevelLoaderScript>().LoadNextScene("Menu");
        
         loadingScreen.SetActive(true);
         UnloadAllScene();
         SceneManager.LoadSceneAsync((int)SceneList.MENU, LoadSceneMode.Additive);
         
         StartCoroutine(GetSceneLoadProgress());

    }

    public void ChangeToRegister()
    {
        // levelLoader.GetComponent<LevelLoaderScript>().LoadNextScene("Registration");

        loadingScreen.SetActive(true);
        UnloadAllScene();
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneList.REGISTRASI, LoadSceneMode.Additive));

        StartCoroutine(GetSceneLoadProgress());
    }
    
    public void ChangeToMain()
    {
        // levelLoader.GetComponent<LevelLoaderScript>().LoadNextScene("Registration");

        loadingScreen.SetActive(true);
        // UnloadAllScene();
        sceneLoading.Add(SceneManager.LoadSceneAsync((int)SceneList.MAIN, LoadSceneMode.Additive));
        sceneLoading.Add(SceneManager.UnloadSceneAsync((int)SceneList.MENU));
        StartCoroutine(GetSceneLoadProgress());
    }

    private IEnumerator GetSceneLoadProgress()
    {
        for (int i = 0; i < sceneLoading.Count; i++)
        {
            while (!sceneLoading[i].isDone)
            {
                yield return null;
            }
        }
        
        loadingScreen.gameObject.SetActive(false);
        
    }

    private void UnloadAllScene()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene _scene = SceneManager.GetSceneAt(i);
            if (_scene.name != SceneManager.GetActiveScene().name)
            {
                sceneLoading.Add(SceneManager.UnloadSceneAsync(_scene));
            }
        }
    }
}
