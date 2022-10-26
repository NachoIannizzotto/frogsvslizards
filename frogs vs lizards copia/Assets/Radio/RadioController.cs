using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    [Header("List of Tracks")]

    [SerializeField] private Track[] audioTracks;
    private int trackIndex;

    [Header("Text UI")]

    [SerializeField] private Text trackTextUI;

    private AudioSource radioAudiosource;

    private void Start()
    {

        radioAudiosource = GetComponent<AudioSource>();

        trackIndex = 1;

        radioAudiosource.clip = audioTracks[trackIndex].trackAudioClip;
        trackTextUI.text = audioTracks[trackIndex].name;
    }

    public void SkipForwardButton()
    {
        if (trackIndex < audioTracks.Length - 1)
        {
            trackIndex++;
            StartCoroutine(FadeOut(radioAudiosource, 0.5f));
        }
    }

    public void SkipBackwardsButton()
    {
        if (trackIndex >= 1)
        {
            trackIndex--;
            StartCoroutine(FadeOut(radioAudiosource, 0.5f));
        }    
    }

   void UpdateTrack(int index) 
    {
        radioAudiosource.clip = audioTracks[index].trackAudioClip;
        trackTextUI.text = audioTracks[index].name;
    }

    public void AudioVolume(float volume)
    {
        radioAudiosource.volume = volume;
    }



    public void PlayAudio()
    {
        StartCoroutine(FadeIn(radioAudiosource, 0.5f));
    }
    public void PauseAudio()
    {
        radioAudiosource.Pause();
    }
    public void StopAudio()
    {
        StartCoroutine(FadeOut(radioAudiosource, 0.5f));
    }

    public IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        UpdateTrack(trackIndex);

    }

    public IEnumerator FadeIn(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < startVolume)
        {
            audioSource.volume += startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.volume = startVolume;
    }

}
