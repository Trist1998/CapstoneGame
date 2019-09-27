using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Asensio (The Lifting Charm)";

    public float shootForwardForce;

    private LiftEffect attached;
    private bool fireable = false;
    
    [SerializeField]
    private float comboPoints;
    [SerializeField]
    private float maxComboPoints;
    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        attached = hit.AddComponent<LiftEffect>();
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
        if (attached == null) return;
        
        attached.endEffect();
        fireable = false;
        
            
    }

    public override string getName()
    {
        return SPELL_NAME;
    }
}
