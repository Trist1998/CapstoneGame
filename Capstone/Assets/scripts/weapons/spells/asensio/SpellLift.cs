using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio (The Lifting Charm)";

    public float shootForwardForce;

    private LiftEffect attached;
    private bool fireable = false;
    private Projectile current;
    public Projectile whalePrefab;
    public float blastRadius;
    public float force;
    public float damage;
    
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        AICharacter c = hit.transform.root.GetComponent<AICharacter>();
        if (c != null)
        {
            attached = c.childBody.gameObject.AddComponent<LiftEffect>();
        }
        else
        {
            attached = hit.AddComponent<LiftEffect>();
        }
        
        attached.startEffect(item);
    }

    public override void primaryFire(Item item)
    {
        if (attached != null)
        {
            if(!fireable)
            {
                attached.distance = 4;
                fireable = true;
            }
            else
            {
                attached.shootForward(shootForwardForce);
                attached = null;
                fireable = false;
            }

        }
        else
            base.primaryFire(item);
    }

    public override void secondaryFire(Item item)
    {
        if (attached == null)
        {
            if(comboPoints < maxComboPoints) return;
            comboPoints = 0;
            base.secondaryFire(item);
        }
        else
        {
            attached.endEffect();
            attached = null;
            fireable = false;
        }
    }
    public override void processSecondaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        if(current == null)
        {
            current = Instantiate(whalePrefab, (hitPoint + new Vector3(0, 15, 0)), new Quaternion());
            current.setEffectValues(item, this);
            current.setPrimaryEffect(false);
        }
        else
        {
            Collider[] objects = Physics.OverlapSphere(hitPoint, blastRadius);
            foreach (var colliderObject in objects)
            {
                Rigidbody rigid = colliderObject.gameObject.GetComponent<Rigidbody>();
                if (rigid != null)
                {
                    AICharacter c = colliderObject.GetComponent<AICharacter>();
                    Vector3 displacement = colliderObject.transform.position - hitPoint;
                    if (c != null)
                    {
                        c.gameObject.AddComponent<RagdollEffect>().startEffect(1.5f);
                    
                        c.takeDamage(0.5f * damage * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1));
                    }
                    rigid.AddForce(force * Mathf.Clamp(1 - displacement.magnitude/blastRadius, 0, 1) * displacement.normalized, ForceMode.VelocityChange);

                }
            }
            current = null;
            base.processSecondaryHit(item, hit, hitPoint, direction);
        }
        
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
