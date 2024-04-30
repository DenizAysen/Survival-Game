using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundStepsSound : MonoBehaviour
{
    public AudioSource footStepAudioSource;
    public AudioClip footStepAudioClip;

    private float _lastTime = 0f;
    private float _duration = 0f;
    private void Start()
    {
        _duration = footStepAudioClip.length;
    }
    public void PlayFootStepSound()
    {
        if(_lastTime == 0)
        {
            footStepAudioSource.PlayOneShot(footStepAudioClip);
        }
        if(Time.time  - _lastTime >= _duration)
        {
            _lastTime = Time.time;
            footStepAudioSource.PlayOneShot(footStepAudioClip);
        }
    }
}
