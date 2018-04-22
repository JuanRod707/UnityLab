using System.Collections;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public float RateOfFire;
    public float Accuracy;
    public float AimDistance;
    public float Range;
    public float Recoil;
    public float AimRecovery;
    public float MinAccuracy;

    public Transform MuzzleSpot;

    public GameObject ShotLinePf;
    public GameObject HitParticle;
    public ParticleSystem MuzzleEffect;
    public AdvancedCrosshair AdvCrosshair;

    private bool isCycling;
    public float currentAccuracy;

    private float Inaccuracy
    {
        get { return 1 - (100f / currentAccuracy); }
    }

    void Start()
    {
        currentAccuracy = Accuracy;
    }

    void Update()
    {
        if (!isCycling && currentAccuracy < Accuracy)
        {
            currentAccuracy += AimRecovery;
        }

        AdvCrosshair.UpdateDimension(Inaccuracy);       
    }

    void DebugStuff()
    {
        var aimPoint = GetRandomArcPoint();
        Debug.DrawRay(MuzzleSpot.position, aimPoint - MuzzleSpot.position);
    }

    public void Shoot()
    {
        if (!isCycling)
        {
            var aimPoint = GetRandomArcPoint();
            var firePosition = MuzzleSpot.position;
            var ray = new Ray(firePosition, aimPoint - firePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, Range))
            {
                DisplayHit(hit.point);
                DisplayShot(hit.point);
            }
            else
            {
                DisplayShot(aimPoint);
            }
            
            if (currentAccuracy > 1 && currentAccuracy > MinAccuracy)
            {
                currentAccuracy -= Recoil;
            }

            DisplayMuzzle();
            StartCoroutine(CycleBullet());
        }
    }

    IEnumerator CycleBullet()
    {
        isCycling = true;
        yield return new WaitForSeconds(RateOfFire);
        isCycling = false;
    }

    Vector3 GetRandomArcPoint()
    {
        var randomPoint = Random.insideUnitSphere * Inaccuracy;
        var cam = Camera.main.transform;
        var result = (cam.forward * Range) + randomPoint;

        var ray = new Ray(cam.position, result);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Range))
        {
            result = hit.point;
        }

        return result;
    }

    void DisplayShot(Vector3 hitPoint)
    {
        var shotLine = Instantiate(ShotLinePf).GetComponent<LineRenderer>();
        shotLine.SetPositions(new [] { MuzzleSpot.position, hitPoint });
    }

    void DisplayHit(Vector3 hitPoint)
    {
        Instantiate(HitParticle, hitPoint, Quaternion.identity);
    }

    void DisplayMuzzle()
    {
        MuzzleEffect.Emit(1);
    }
}
