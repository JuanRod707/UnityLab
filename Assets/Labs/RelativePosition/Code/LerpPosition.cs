using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition : MonoBehaviour
{
    public Transform Anchor1;
    public Transform Anchor2;
    public float LerpFactor;
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	    this.transform.position = Vector3.Lerp(Anchor1.position, Anchor2.position, LerpFactor);
	}
}
