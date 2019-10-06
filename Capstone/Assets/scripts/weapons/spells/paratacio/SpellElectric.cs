using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class SpellElectric : AbstractWeaponEffect
{
    public readonly string SPELL_NAME = "Paratacio (The Electric Charm)";
    public float damagePerSecond;
    [SerializeField]
    private LightningBoltScript lightningBolt;

    private LightningBoltScript lightning;

    public override void processPrimaryHit(Item item, GameObject hit, Vector3 hitPoint, Vector3 direction)
    {
        hit.GetComponent<WorldObject>()?.takeDamage(damagePerSecond * Time.deltaTime);//TODO more damage if wet state and damage nearby wet objects
        if(lightning == null)
            lightning = Instantiate(lightningBolt, hitPoint, Quaternion.identity);
        lightning.StartPosition = item.transform.position;
        lightning.EndPosition = hitPoint;
        lightning.Trigger();
        base.processPrimaryHit(item, hit, hitPoint, direction);
    }

    public override string getName()
    {
        return SPELL_NAME;
    }

}
