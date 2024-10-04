using UnityEngine;

public class PlayAnimationOnCollision : ObjectCollisionActions
{
    public Animator collidedObjectAnimator;

    protected override void OnCollisionEnter(Collision other)
    {
        if (collidedObjectAnimator != null)
        {
            collidedObjectAnimator.Play("CannonFire");
        }
    }
}
