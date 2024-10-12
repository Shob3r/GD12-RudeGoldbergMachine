using UnityEngine;

public class ApplyForceOnCollision : ObjectCollisionActions
{
    [Tooltip("In meters/second")]
    public float targetAcceleration = 5.5f; // I would assume that that this is represented as m/s

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);

        var collidedGameObject = other.gameObject;
        if (DoesColliderHaveRigidBody(collidedGameObject))
        {
            var collidedRigidBody = collidedGameObject.GetComponent<Rigidbody>();
            float forceRequired =
                collidedRigidBody.mass * targetAcceleration; // F=ma (High school physics coming in clutch) 

            collidedRigidBody.AddForce(Vector3.forward * forceRequired, ForceMode.Impulse);
        }
        else
        {
            if (enableDebugMessages)
                Debug.LogWarning($"{other.gameObject.name} Does not have a RigidBody attached to it!");
        }
    }

    private bool DoesColliderHaveRigidBody(GameObject collidedObject)
    {
        return collidedObject.GetComponent<Rigidbody>() != null;
    }
}