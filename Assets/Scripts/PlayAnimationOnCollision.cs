using UnityEngine;

public class PlayAnimationOnCollision : ObjectCollisionActions
{
    public Animator collidedObjectAnimator;
    public string animationTriggerName = "Triggered";

    protected override void OnCollisionEnter(Collision other)
    {
        if (collidedObjectAnimator != null)
        {
            collidedObjectAnimator.SetBool(animationTriggerName, true);
        }
    }
}
