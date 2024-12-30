using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAudioPlayer 
{
    void Play(AudioClip clip, Vector3 position, float volume, bool looping = false);
    void Stop();
    bool IsPlaying { get; }
}
