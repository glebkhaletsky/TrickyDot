using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    [SerializeField] GameObject FadeIn;
    public void Play()
{
    SceneManager.LoadScene(1);
}


    public void StartGame()
    {
        FadeIn.SetActive(true);
        Invoke("Play", 1.5f);
    }

    public void StartClick()
    {
        Invoke("StartGame", 1f);
    }
}
