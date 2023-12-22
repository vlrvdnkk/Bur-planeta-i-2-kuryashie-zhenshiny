using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private AudioClip[] audio = new AudioClip[2];
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volumeSlider.value = audioSource.volume;
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float volume)
    {
        audioSource.volume = volume;
    }
    public void AudioChange(int num)
    {
        if (audioSource.clip != audio[num])
        {
            audioSource.clip = audio[num];
            audioSource.Play();
        }
    }
}
