using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public float Speed;
    public float TurnSpeed;

    public GameObject MissilePrefab;
    public Transform TargetCube;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(Vector3.forward*Speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(-Vector3.forward * Speed);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Translate(-Vector3.right * Speed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            this.transform.Translate(Vector3.right * Speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * TurnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.up * -TurnSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var missile = Instantiate(MissilePrefab, this.transform.position, this.transform.rotation).GetComponent<HomingMissile>();
            missile.SetTarget(TargetCube);
            var missileLerp = missile.GetComponent<HomingMissileLerp>();
            missileLerp.SetTarget(TargetCube);
            var missileDirect = missile.GetComponent<HomingDirect>();
            missileDirect.SetTarget(TargetCube);
        }
    }
}
