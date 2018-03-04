using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileContact : MonoBehaviour
{
    public GameObject ExplosionPf;

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(ExplosionPf, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
