/*
 * Lucas Johnson
 * Assignment 5B
 * Controls shooting
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithRaycasts : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float hitForce = 10f;
    public Camera cam;

    public ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hitInfo;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, range))
        {
            Debug.Log(hitInfo.transform.name);

            Target target = hitInfo.transform.gameObject.GetComponent<Target>();

            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hitInfo.rigidbody != null)
            {
                hitInfo.rigidbody.AddForce(cam.transform.TransformDirection(Vector3.forward) * hitForce, ForceMode.Impulse);
            }
        }
    }
}
