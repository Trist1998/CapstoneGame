using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxWorldObject : WorldObject
{
    public WorldObject parent;
    public override void interact(IItemUser player)
    {
        parent.interact(player);
    }
}
