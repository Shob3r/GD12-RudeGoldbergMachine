using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnCollision : ObjectCollisionActions
{
    public AudioClip soundEffect;
    private AudioSource effectSource;

    public int timesToPlay = 2;
    private short timesHit = 0;

    private void Start()
    {
        effectSource = GetComponent<AudioSource>();
    }
    
    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        
        if (timesHit < timesToPlay)
        {
            timesHit++;
            effectSource.PlayOneShot(soundEffect);
        }
    }
}
