using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour, IWorldObject
{
    [SerializeField] 
    private string itemName;
    [SerializeField] 
    private string description;
    [SerializeField]
    public bool equipable = true;
    [SerializeField]
    public GameObject modelPrefab;

    private GameObject characterModel;
    public Vector3 relativePosition;
    public Vector3 relativeRotation;
    public IItemUser user;

    public void interact(IItemUser user)
    {
        float dist = Vector3.Distance(user.getHandBone().transform.position, transform.position);

        if (user != null && dist < 5 && equipable)
        {
            user.addItem(this);
        }
    }

    public bool isEquipped()
    {
        return user != null && user.getEquippedItem() == this;
    }

    public virtual void equipItem(IItemUser user)
    {
        this.user = user;
        setLayerRecursively(gameObject, user.getHandBone().layer);
        InteractControl control = user.getGameObject().GetComponent<InteractControl>();
        if (control == null) return;
        GameObject hand = control.getHandBoneCharacter();

        characterModel = Instantiate(modelPrefab, hand.transform.position, hand.transform.rotation);

        characterModel.transform.parent = hand.transform;
        setLayerRecursively(characterModel, hand.layer);
    }

    public virtual void unequipItem()
    {
        setLayerRecursively(gameObject, LayerMask.NameToLayer("Default"));
        user = null;
        Destroy(characterModel);
    }

    private void OnDisable()
    {
        if(characterModel != null)
            characterModel.SetActive(false);
    }

    private void OnEnable()
    {
        if(characterModel != null)
            characterModel.SetActive(true);
    }


    public virtual void usePrimaryActionDown()
    {}

    public virtual void usePrimaryActionUp()
    {}

    public virtual void useSecondaryActionDown()
    {}

    public virtual void useSecondaryActionUp()
    {}

    public virtual string getItemName()
    {
        return itemName;
    }
    
    protected string getItemDescription()
    {
        return description;
    }

    public virtual bool requireAmmoBar()
    {
        return false;
    }
    
    public virtual bool requireComboBar()
    {
        return false;
    }
    
    public virtual float getAmmoPercentage()
    {
        return 0;
    }

    public virtual float getComboPercentage()
    {
        return 0;
    }
    
    public virtual string getDisplayAmmo()
    {
        return "";
    }
    
    public virtual string getDisplayCombo()
    {
        return "";
    }

    public virtual void reload()
    {
    }

    private void setLayerRecursively(GameObject obj, int newLayer)
    {
        if (null == obj)
            return;
        obj.layer = newLayer;
        foreach (Transform child in obj.transform)
        {
            if (null == child) continue;
            setLayerRecursively(child.gameObject, newLayer);
        }
    }
}
