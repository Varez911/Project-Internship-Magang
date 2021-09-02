using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GantiScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void GantiKeRegistrasi()
    {
        SceneManager.LoadScene("Registration");
    }

    public void GantiKeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
