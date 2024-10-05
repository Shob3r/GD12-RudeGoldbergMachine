using UnityEngine;

public class ApplyForceOnCollision : ObjectCollisionActions
{
    public float targetAcceleration = 5.5f;
    protected override void OnCollisionEnter(Collision other)
    {
        GameObject collidedGameObject = other.gameObject;
        if (DoesColliderHaveRigidBody(collidedGameObject))
        {
            Rigidbody collidedRigidBody = collidedGameObject.GetComponent<Rigidbody>();
            float forceRequired = collidedRigidBody.mass * targetAcceleration;
            
            collidedRigidBody.AddForce(Vector3.forward * forceRequired, ForceMode.Impulse);
        }
        else
        {
            if (enableDebugMessages) Debug.LogWarning($"{other.gameObject.name} Does not have a RigidBody attached to it!");
        }
    }

    private bool DoesColliderHaveRigidBody(GameObject collidedObject)
    {
        return collidedObject.GetComponent<Rigidbody>() != null;
    }
}
