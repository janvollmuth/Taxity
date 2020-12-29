using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameAudioHandler : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource PickUpSound;
    public AudioSource WinSound;
    public AudioSource EngineSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundMusic.volume = GameManager.Instance.MasterVolume;
    }

    public void PlayPickUpSound()
    {
        PickUpSound.Play();
    }

    public void StopBackgroundMusic()
    {
        BackgroundMusic.Stop();
    }

    public void PlayWinSound()
    {
        WinSound.Play();
    }

    public AudioSource GetEngineSound()
    {
        return EngineSound;
    }
}
