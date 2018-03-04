using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutInPosition : MonoBehaviour
{
    public GameObject target;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = target.transform.forward;
    }
}