using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledAudioPlayer : MonoBehaviour, IAudioPlayer
{
    private AudioSource audioSource;

    public bool IsPlaying => audioSource.isPlaying;

    public void Initialize()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;  // 3D Audio
    }

    public void Play(AudioClip clip, Vector3 position, float volume, bool looping = false)
    {

        transform.position = position;
        audioSource.clip = clip;
        audioSource.volume = volume;
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void Stop()
    {
        audioSource.Stop();
    }
}
