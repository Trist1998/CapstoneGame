using UnityEngine;

public interface IItemUser
{
    Vector3 getItemAimDirection();
    Vector3 getItemAimPosition();
    Item getEquippedItem();
    void addItem(Item item);
    GameObject getHandBone();
    GameObject getGameObject();
}