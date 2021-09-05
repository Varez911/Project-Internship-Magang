using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioButtonScript : MonoBehaviour
{
    public void PlayDeskripsiAudio(GameObject _muteButton)
    {
        GameObject _playButton = EventSystem.current.currentSelectedGameObject;
        _playButton.SetActive(false);
        _muteButton.SetActive(true);
    }

    public void StopDeskripsiAudio(GameObject _playButton)
    {
        GameObject _muteButton = EventSystem.current.currentSelectedGameObject;
        _muteButton.SetActive(false);
        _playButton.SetActive(true);

    }
}
