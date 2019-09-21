using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAndHeavyShooting : MonoBehaviour
{
    //TODO: Increase fireRate to 5 if heavy mode is on and fire heavy shot
    //TODO: Increase damage to 100 i heavy mode is on
    //TODO: Decrease shot range to 20 if heavy mode is on
    //TODO: Add shot landing VFX to container and delete each one after 2 seconds
    [SerializeField] [Range(0.25f, 5.0f)] private float fireRate = 1;
    [SerializeField] [Range(1, 100)] private int damage = 1;
    [SerializeField] [Range(100.0f, 20.0f)] private float shotRange = 100.0f;
    private float timer;

    [SerializeField] private ParticleSystem shotImpact;
    [SerializeField] private ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireWeapon();
            }
        }
    }

    private void FireWeapon()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);

        Debug.DrawRay(ray.origin, ray.direction * shotRange, Color.red, 2.0f);

        RaycastHit hitInfo;

        muzzleFlash.Play();

        if (Physics.Raycast(ray, out hitInfo, shotRange))
        {
            var health = hitInfo.collider.GetComponent<Health>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }

            Instantiate(shotImpact, hitInfo.point, Quaternion.identity);
        }
    }
}
