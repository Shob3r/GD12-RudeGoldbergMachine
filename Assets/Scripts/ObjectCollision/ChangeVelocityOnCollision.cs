using UnityEngine;

public class ChangeVelocityOnCollision : ObjectCollisionActions
{
    public Vector3 newVelocity = Vector3.zero;

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
        if (other.gameObject.GetComponent<Rigidbody>() != null)
            other.gameObject.GetComponent<Rigidbody>().velocity = newVelocity;
    }
}