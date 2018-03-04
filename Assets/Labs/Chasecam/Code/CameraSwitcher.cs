using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Chasecam>().enabled = true;
            this.transform.SetParent(null);
        }
    }
}
