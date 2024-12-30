using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] [Range(0f, 1f)] private float volume = 0.5f;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip landSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AudioClip moveSound;
    [SerializeField] private AudioManager audioManager;

    private PooledAudioPlayer walkAudioPlayer;
    private PooledAudioPlayer jumpAudioPlayer;
    private PooledAudioPlayer reloadAudioPlayer;


    void OnEnable()
    {
        GameEvents.OnShoot += PlayShootSound;
        GameEvents.OnPlayerJump += PlayJumpSound;
        GameEvents.OnPlayerLand += PlayLandSound;
        GameEvents.OnReloadStart += PlayReloadSound;
        GameEvents.OnPlayerMove += PlayMoveSound;
        GameEvents.OnPlayerStopMove += StopMoveSound;
        GameEvents.OnReloadStop += StopReloadSound;
    }

    void OnDisable()
    {
        GameEvents.OnShoot -= PlayShootSound;
        GameEvents.OnPlayerJump -= PlayJumpSound;
        GameEvents.OnPlayerLand -= PlayLandSound;
        GameEvents.OnReloadStart -= PlayReloadSound;
        GameEvents.OnPlayerMove -= PlayMoveSound;
        GameEvents.OnPlayerStopMove -= StopMoveSound;
        GameEvents.OnReloadStop -= StopReloadSound;
    }


    private  void PlayShootSound()
    {
        PlaySound(shootSound, shootSound.length);
    }
    private  void PlayJumpSound()
    {
        if(jumpAudioPlayer == null)
        {
           jumpAudioPlayer = PlayLoopingSound(jumpSound);
        }
        jumpAudioPlayer.Play(jumpSound, transform.position, volume, true);
    }

    private void StopJumpSound()
    {
        if(jumpAudioPlayer == null)
        {
           jumpAudioPlayer = PlayLoopingSound(jumpSound);
        }
        jumpAudioPlayer.Stop();
    }
    private  void PlayLandSound()
    {
        StopJumpSound();
        PlaySound(landSound, landSound.length);
    }
    private  void PlayReloadSound()
    {
        if(reloadAudioPlayer == null)
        {
            reloadAudioPlayer=PlayLoopingSound(reloadSound);
        }
        reloadAudioPlayer.Play(reloadSound, transform.position, volume, true);
    }
    private void StopReloadSound()
    {
        if(reloadAudioPlayer == null)
        {
            reloadAudioPlayer=PlayLoopingSound(moveSound);
        }
        reloadAudioPlayer.Play(reloadSound, transform.position, volume, true);
    }
    private void PlayMoveSound()
    {
        if(walkAudioPlayer == null)
        {
            walkAudioPlayer=PlayLoopingSound(moveSound);
        }
        walkAudioPlayer.Play(moveSound, transform.position, volume, true);
    }

    private void StopMoveSound()
    {
        if(walkAudioPlayer == null)
        {
            walkAudioPlayer=PlayLoopingSound(moveSound);
        }
        walkAudioPlayer.Stop();
    }

    private void PlaySound(AudioClip clip, float duration)
    {
         audioManager.PlaySound(clip, transform.position, volume, duration).Forget();
    }
    private PooledAudioPlayer PlayLoopingSound(AudioClip clip)
    {
        return walkAudioPlayer=audioManager.PlayLoopingSound(clip, transform.position, volume);
    }
}
