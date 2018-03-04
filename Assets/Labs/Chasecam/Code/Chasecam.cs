using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasecam : MonoBehaviour
{
    public Transform TargetView;
    public Transform TargetPos;

    public float MoveSpeed;
    
    void FixedUpdate()
    {
        if (TargetPos != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, TargetPos.position, MoveSpeed);
        }

        if (TargetView != null)
        {
            this.transform.LookAt(TargetView);
        }

        var eul = this.transform.eulerAngles;
        eul.z = 0f;
        this.transform.eulerAngles = eul;
    }
}
