using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPool 
{
    private readonly Queue<PooledAudioPlayer> pool = new Queue<PooledAudioPlayer>();
    private readonly Transform parent;

    public AudioPool(int initialSize, Transform poolParent)
    {
        parent = poolParent;
        for (int i = 0; i < initialSize; i++)
        {
            CreateNewPlayer();
        }
    }

    private PooledAudioPlayer CreateNewPlayer()
    {
        var newPlayer = new GameObject("PooledAudio").AddComponent<PooledAudioPlayer>();
        newPlayer.transform.SetParent(parent);
        newPlayer.Initialize();
        pool.Enqueue(newPlayer);
        return newPlayer;
    }

    public PooledAudioPlayer Get()
    {
        if (pool.Count == 0)
        {
            CreateNewPlayer();
        }
        return pool.Dequeue();
    }

    public void ReturnToPool(PooledAudioPlayer player)
    {
        player.Stop();
        pool.Enqueue(player);
    }
}
