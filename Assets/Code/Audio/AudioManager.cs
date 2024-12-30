using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private Transform poolContainer;

    private AudioPool audioPool;

    private void Awake()
    {
        audioPool = new AudioPool(poolSize, poolContainer);
    }

    public async UniTask PlaySound(AudioClip clip, Vector3 position, float volume = 1f, float duration = 5f)
    {
        var player = audioPool.Get();
        player.Play(clip, position, volume);
        await UniTask.Delay((int)(duration * 1000));
        audioPool.ReturnToPool(player);
    }

    public PooledAudioPlayer PlayLoopingSound(AudioClip clip, Vector3 position, float volume)
    {
        var player = audioPool.Get();
        player.Play(clip, position, volume, true);
        return player;
    }

    public void StopLoopingSound(PooledAudioPlayer player)
    {
        player.Stop();
        audioPool.ReturnToPool(player);
    }
}
