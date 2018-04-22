using UnityEngine;

public class PhysicsPushable : MonoBehaviour, IPushable
{
    private Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    public void PushFrom(Vector3 fromPos, float pushForce)
    {
        var distance = Vector3.Distance(transform.position, fromPos);
        var pushVector = transform.InverseTransformPoint(fromPos).normalized;

        pushVector *= -pushForce/distance;
        
        body.AddForce(pushVector);
    }
}
