using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetection : MonoBehaviour
{
    public Transform Target;
    public bool IsRight;
    public bool IsFront;
    public DynamicLabel FrontBack;
    public DynamicLabel RightLeft;
    
    void FixedUpdate ()
	{
	    if (Target != null)
	    {
	        var transformedPos = this.transform.InverseTransformPoint(Target.position);
	        IsRight = transformedPos.x > 0;
	        IsFront = transformedPos.z > 0;
	    }
	}

    void UpdateStrings()
    {
        if (IsRight)
        {
            RightLeft.SetLabel("right");
        }
        else
        {
            RightLeft.SetLabel("left");
        }

        if (IsFront)
        {
            FrontBack.SetLabel("front");
        }
        else
        {
            FrontBack.SetLabel("back");
        }
    }
}
