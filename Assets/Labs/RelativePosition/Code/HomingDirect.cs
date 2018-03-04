using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingDirect : MonoBehaviour
{
    public float Speed;
    private Transform Target;
	
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
            this.transform.LookAt(Target.position);       
        }
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
