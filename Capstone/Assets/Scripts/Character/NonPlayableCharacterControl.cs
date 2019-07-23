using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayableCharacterControl : AbstractCharacterControl, ItemUser
{
    private HealthControl health;

    [SerializeField]
    private Item primaryWeapon;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<HealthControl>();
        primaryWeapon.user = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(true)
            primaryWeapon.usePrimaryActionDown();
    } 

    public Vector3 getUserAimDirection()
    {
        return transform.forward;
    }

    public Vector3 getUserAimPosition()
    {
        return primaryWeapon.transform.position;
    }

    public Item getEquippedItem()
    {
        return primaryWeapon;
    }
}
