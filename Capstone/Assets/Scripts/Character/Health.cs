using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 1000f;
    public GameObject explosion;

    public void takeDamage(float amount, Vector3 direction, float force)
    {
        health -= amount;
        GetComponent<Rigidbody>().AddForce(direction * force);

        if (health <= 0)
        {
            explode();
            die();
        }
    }
    void die()
    {
        Destroy(gameObject);
    }

    void explode()
    {
        ParticleSystem particles = Instantiate(explosion.GetComponent<ParticleSystem>(), this.transform.position, this.transform.rotation);
        particles.Play();
        Destroy(gameObject, particles.main.duration);
    }
}
