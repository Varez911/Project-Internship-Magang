using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour
{
    public Button registrasiButton;
    public Button exitButton;
    
    private ChangeScene _changeScene;
    
    // Start is called before the first frame update
    void Start()
    {
        _changeScene = GameObject.Find("App Manager").GetComponent<ChangeScene>();

        if (registrasiButton)
        {
            registrasiButton.onClick.AddListener(_changeScene.ChangeToRegister);
        }

        if (exitButton)
        {
            exitButton.onClick.AddListener(_changeScene.ChangeToMenu);
        }
    }

}
