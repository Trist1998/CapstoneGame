using UnityEngine;

namespace Objects
{
    public interface IItemUser
    {
        Vector3 getItemAimDirection();
        Vector3 getItemAimPosition();
        Item getEquippedItem();
        GameObject getHandBone();
    }
}