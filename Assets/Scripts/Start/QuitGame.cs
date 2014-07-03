using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    private AudioSource audioClip;
    private bool quitGame = false;

    void Start() 
    {
        audioClip = GameObject.FindGameObjectWithTag("UI").GetComponent<AudioSource>();
    }

    void OnClick()
    {
        audioClip.Play();
    }

    void Update()
    {
        if (audioClip.isPlaying)
        {
            quitGame = true;
        }
        if (!audioClip.isPlaying && quitGame)
        {
            Application.Quit();
        }
    }
}
