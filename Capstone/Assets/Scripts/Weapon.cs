using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon: MonoBehaviour, IItem
{
    public const int FIRE_MODE_FULL_AUTO = 0;
    public const int FIRE_MODE_SEMI_AUTO = 1;
    public const int FIRE_MODE_NOT_AUTO = 2;//IDK
    public int fireModeId;
    public float range = 100;
    public AudioSource sound;
    bool fired = false;
    public GameObject bullethole;
    public float damage;
    public float bpm = 0.5f;
    public bool projectile = false;
    public int magSize = 20;
    public int spareAmmo = 60;
    public float force;
    public ParticleSystem muzzleFlash;

    public Text text;
    int countShots = 0;
    int countHits = 0;

    public void use(ObjectPickup pickup)
    {
        //Debug.DrawRay(pickup.fpsCam.transform.position, pickup.fpsCam.transform.forward * range, Color.red);
        if (Input.GetAxis("Fire1") == 1)
        {

            if (!fired)
                fire(pickup);
            fired = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            fired = false;
        }
    }

    public void fire(ObjectPickup pickup)
    {
        countShots++;
        sound.Play();
        muzzleFlash.Play();
        RaycastHit hit;
        
        if (Physics.Raycast(pickup.player.cam.transform.position, pickup.player.cam.transform.forward, out hit, range))
        {
            GameObject obj = Instantiate(bullethole,hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
            obj.transform.parent = hit.collider.transform;
            Health health = hit.collider.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.takeDamage(damage, pickup.player.cam.transform.forward.normalized, force);
                countHits++;
            }
                         
        }
        text.text = " Shots Hit/Fired: " + countHits + "/" + countShots; 
    }
}
