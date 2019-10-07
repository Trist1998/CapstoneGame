using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour, IWorldObject
{
    [SerializeField]
    private Spawner spawner;
    public bool destructable;
    
    public float impulseThreshold;
    public float timeToDestroy;
    public bool projectile = false;
    public float maxHitPoints;
    public float hitPoints = 1000f;
    public GameObject explosion;
    public int rewardPoints;

    protected virtual void Start()
    {
        setHealth(maxHitPoints);
    }

    public virtual void interact(IItemUser user)
    {}

    public void setSpawner(Spawner spawner)
    {
        this.spawner = spawner;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (projectile && collision.impulse.magnitude > impulseThreshold)
        {
            takeDamage(collision.impulse.magnitude);
            print(collision.impulse.magnitude + " impulse");
        }

    }

    public virtual void destroyObject()
    {
        if (spawner != null)
            spawner.objectDestroyed(rewardPoints);
        Destroy(gameObject, timeToDestroy);
    }

    public void takeDamage(float amount)
    {
        if (isDead() || !destructable) return;
        hitPoints -= amount;

        if (isDead())
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
        destroyObject();
        Destroy(this);
    }

    private void explode()
    {
        if (explosion == null) return;
        
        ParticleSystem particles = Instantiate(explosion.GetComponent<ParticleSystem>(), transform.position, transform.rotation);
        particles.Play();
        Destroy(gameObject, particles.main.duration);
    }

    public bool isDead()
    {
        return hitPoints <= 0;
    }
    
    public void heal(float toAdd)
    {
        if(isDead()) return;
        hitPoints = Mathf.Clamp(hitPoints + toAdd, 0 , maxHitPoints);
    }
    
    public void setHealth(float hitPoints)
    {
        this.hitPoints = hitPoints;
    }
}
