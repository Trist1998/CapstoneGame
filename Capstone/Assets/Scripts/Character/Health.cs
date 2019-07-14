using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 1000f;
    public GameObject explosion;

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
    void die()
    {
        Destroy(gameObject);
    }

    void explode()
    {
        if(explosion != null)
        {
            ParticleSystem particles = Instantiate(explosion.GetComponent<ParticleSystem>(), this.transform.position, this.transform.rotation);
            particles.Play();
            Destroy(gameObject, particles.main.duration);
        }      
    }
}
