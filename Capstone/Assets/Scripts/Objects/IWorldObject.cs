﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorldObject
{
    void interact(IItemUser player);
}
