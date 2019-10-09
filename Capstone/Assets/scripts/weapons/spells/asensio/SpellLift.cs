using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellLift : AbstractWeaponEffect
{

    public float shootForwardForce;
    private LiftEffect attached;
    private bool fireable = false;

    /*
     * Weapon effect for Asensio
     */
    
    
    /*
     *  Attaches lift effect if hit object not already attached
     */
    
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

    /*
     * If attached equals null fires as usual
     * else it either pulls in item or shoots it forward
     * depending on the fireable bool
     */
    public override void primaryFire(Item item)
    {
        if (attached != null)
        {
            if(!fireable)
            {
                attached.distance = 3;
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
    
    /*
     * Ends attached effect and sets attached reference to null
     */

    public override void secondaryFire(Item item)
    {
        if (attached == null) return;
        attached.endEffect();
        attached = null;
        fireable = false;
    }

    /*
     * Used to check if is secondary fire is available in WeaponItem.canSecondaryFire()
     */
    public override bool canComboFire()
    {
        return attached != null;
    }
}
