using UnityEngine;

public abstract class ObjectCollisionActions : MonoBehaviour
{
    public bool enableDebugMessages;
    public int framesUntilCollisionDetectionEnabled = 240;

    private long timeSinceGameStarted;

    private void Update()
    {
        timeSinceGameStarted = Time.frameCount;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (timeSinceGameStarted < framesUntilCollisionDetectionEnabled) return;

        if (enableDebugMessages) Debug.Log($"{other.gameObject.name} collided with {gameObject.name}");
    }
}