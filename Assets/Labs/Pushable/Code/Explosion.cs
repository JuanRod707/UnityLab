using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class Explosion : MonoBehaviour
{
    public float PushForce;
    public float EffectDuration;

    private float effectElapsed;
    private List<IPushable> pushables;

    void Start()
    {
        effectElapsed = EffectDuration;
        pushables = new List<IPushable>();
    }

    void Update()
    {
        if (effectElapsed > 0)
        {
            effectElapsed -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effectElapsed > 0)
        {
            var psh = other.GetComponent<IPushable>();
            if (psh != null && !pushables.Contains(psh))
            {
                pushables.Add(psh);
                psh.PushFrom(transform.position, PushForce);
            }
        }
    }
}
