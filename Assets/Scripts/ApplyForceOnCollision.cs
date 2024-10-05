using UnityEngine;

public class ApplyForceOnCollision : ObjectCollisionActions
{
    public float targetAcceleration = 5.5f;
    protected override void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if (DoesColliderHaveRigidBody(other.gameObject))
        {
            Rigidbody collidedRigidBody = other.gameObject.GetComponent<Rigidbody>();
            float forceRequired = collidedRigidBody.mass * targetAcceleration;
            Debug.Log(forceRequired);
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * forceRequired, ForceMode.Impulse);
            return;
        }
        if(enableDebugMessages) Debug.LogWarning($"{other.gameObject.name} Does not have a RigidBody attached to it!");
    }

    private bool DoesColliderHaveRigidBody(GameObject collidedObject)
    {
        return collidedObject.GetComponent<Rigidbody>() != null;
    }
}
