using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnCollision : ObjectCollisionActions
{
    public AudioClip soundEffect;

    public int timesToPlay = 2;
    private AudioSource effectSource;
    private short timesHit;

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