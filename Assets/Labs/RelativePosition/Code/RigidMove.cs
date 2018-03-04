using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMove : MonoBehaviour
{
    public Transform Target;
	
	void FixedUpdate ()
	{
	    if (Target != null)
	    {
	        this.transform.position = Target.position;
	    }
	}

    public void SetTarget(Transform target)
    {
        Target = target;
    }
}
