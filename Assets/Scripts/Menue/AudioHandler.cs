using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioHandler : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioSource BackgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        VolumeSlider.value = GameManager.Instance.MasterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.Instance.MasterVolume = VolumeSlider.value;
        BackgroundMusic.volume = GameManager.Instance.MasterVolume;
    }
}
