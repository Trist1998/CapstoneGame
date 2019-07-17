using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem particles;
    public AbstractWeaponEffect onHitEffect;
    public Item item;
    private GenericTimer timer;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }
    public void fire(Vector3 position, Vector3 direction, float force, float timeout)
    {
        transform.position = position + direction.normalized;
        Rigidbody rig = GetComponent<Rigidbody>();
        if (rig != null)
            rig.AddForce(direction.normalized * force);
        timer = new GenericTimer(timeout, false);
        if(particles != null)
            particles.Play();
    }

    public void setParticleSystem(ParticleSystem particles)
    {
        this.particles = Instantiate(particles);
        particles.gameObject.transform.parent = gameObject.transform;
    }

    public void setShooter(Item item)
    {
        this.item = item;
    }

    public void setWeaponEffect(AbstractWeaponEffect effect)
    {
        onHitEffect = effect;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer != null && timer.isTimeout(Time.deltaTime))
        {
            Destroy(particles);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject != item.gameObject)
        {
            onHitEffect.processPrimaryHit(item, other.gameObject);
            Destroy(gameObject);
        }
    }

}
