using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float FuseLength;
    public GameObject ExplosionPrefab;

    void Start()
    {
        StartCoroutine(WaitAndExplode());
    }

    IEnumerator WaitAndExplode()
    {
        yield return new WaitForSeconds(FuseLength);
        Explode();
    }

    void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
