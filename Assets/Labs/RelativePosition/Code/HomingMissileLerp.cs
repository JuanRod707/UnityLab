using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileLerp : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;
    private Transform Target;
    public float HomingTimer;
	
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
        if (HomingTimer < 0)
        {
            if (Target != null)
            {
                this.transform.LookAt(GetTurnVector());
            }
        }
        else
        {
            HomingTimer -= Time.fixedDeltaTime;
        }
    }

    Vector3 GetTurnVector()
    {
        return Vector3.Slerp(this.transform.position + this.transform.forward, Target.position, TurnSpeed);
    }

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
