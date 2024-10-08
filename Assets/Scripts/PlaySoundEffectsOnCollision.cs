using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class PlaySoundEffectsOnCollision : ObjectCollisionActions
{
    public List<AudioClip> collisionSfx = new();

    private AudioSource collisionSource;
    public bool playMultiple = false;
    private int timesPlayed = 0;

    private void Start()
    {
        collisionSource = GetComponent<AudioSource>();
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (playMultiple || timesPlayed == 0)
        {
            timesPlayed++;
            int selectedSfx = Random.Range(0, collisionSfx.Count - 1);
            collisionSource.PlayOneShot(collisionSfx[selectedSfx]);
        }
    }
}
