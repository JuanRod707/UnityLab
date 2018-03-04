using UnityEngine;

public class PhysicsPushable : MonoBehaviour, IPushable
{
    private Rigidbody body;
    
    public void PushFrom(Vector3 fromPos, float pushForce)
    {
        RefreshBody();
        var distance = Vector3.Distance(transform.position, fromPos);
        var pushVector = transform.InverseTransformPoint(fromPos);

        pushVector *= -pushForce/distance;
        
        body.AddForce(pushVector);
    }

    void RefreshBody()
    {
        if (body == null)
        {
            body = GetComponent<Rigidbody>();
        }
    }
}
