
using UnityEngine;

public interface ItemUser
{
    Vector3 getUserAimDirection();
    Vector3 getUserAimPosition();

    Item getEquippedItem();
}
