using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{
    public float health = 1000f;
    public GameObject explosion;
    public float impulseThreshold;

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            explode();
            die();
        }
    }
    public void takeDamage(float amount, Vector3 direction, float force)
    {
        takeDamage(amount);
        GetComponent<Rigidbody>().AddForce(direction * force);
    }
    protected virtual void die()
    {
        Destroy(gameObject);
    }

    private void explode()
    {
        if(explosion != null)
        {
            ParticleSystem particles = Instantiate(explosion.GetComponent<ParticleSystem>(), transform.position, transform.rotation);
            particles.Play();
            Destroy(gameObject, particles.main.duration);
        }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.magnitude > impulseThreshold)
        {
            takeDamage(collision.impulse.magnitude);
            print(collision.impulse.magnitude + " impulse");
        }

    }
}
