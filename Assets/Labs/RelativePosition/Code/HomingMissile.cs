using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    private Transform Target;
	
	// Update is called once per frame
    void FixedUpdate()
    {
        Turn();
        MoveForward();
    }

    void MoveForward()
    {
        this.transform.Translate(Vector3.forward * Speed);
    }

    void Turn()
    {
        if (Target != null)
        {
            this.transform.Rotate(Vector3.up * TurnSpeed * GetTurnFactor());       
        }
    }

    int GetTurnFactor()
    {
        var transformedPos = this.transform.InverseTransformPoint(Target.position);
        return transformedPos.x > 0 ? 1 : -1;
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
