using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnCollision : ObjectCollisionActions
{
    public AudioClip soundEffect;
    private AudioSource effectSource;

    public bool playMultiple = false;

    private byte timesHit = 0;

    private void Start()
    {
        effectSource = GetComponent<AudioSource>();
    }
    
    protected override void OnCollisionEnter(Collision other)
    {
        if (timesHit == 0 || playMultiple)
        {
            timesHit++;
            effectSource.PlayOneShot(soundEffect);
        }
    }
}
