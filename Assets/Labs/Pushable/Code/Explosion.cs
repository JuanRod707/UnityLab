using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float PushForce;
    public float EffectDuration;

    private float effectElapsed;
    private List<IPushable> pushables;

    void Start()
    {
        effectElapsed = EffectDuration;
    }

    void Update()
    {
        if (effectElapsed > 0)
        {
            effectElapsed -= Time.deltaTime;
        }
    }

    private List<IPushable> Pushables
    {
        get { return pushables ?? (pushables = new List<IPushable>()); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (effectElapsed > 0)
        {
            var psh = other.GetComponent<IPushable>();
            if (psh != null && !Pushables.Contains(psh))
            {
                Pushables.Add(psh);
                psh.PushFrom(transform.position, PushForce);
            }
        }
    }
}
