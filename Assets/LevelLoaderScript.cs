using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transision;
    public int transisionTime;
    private string sceneTarget;
    
    public void LoadNextScene(string _sceneTarget)
    {
        sceneTarget = _sceneTarget;
        StartCoroutine(TransisionScene());
    }

    private IEnumerator TransisionScene()
    {
        // Play Transision Animation
        transision.SetTrigger("Start");
        
        // Wait
        yield return new WaitForSeconds(transisionTime);
        
        // Load Scene
        SceneManager.LoadScene(sceneTarget);
    }
}
