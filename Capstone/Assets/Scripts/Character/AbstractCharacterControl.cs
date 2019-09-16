using System.Linq;
using UnityEngine;
public class AbstractCharacterControl: WorldObject
{
    public int characterTypeId;
    public int[] enemyTypeId;

    protected void Start()
    {
        base.Start();
    }
    
    public bool isCharacterEnemy(AbstractCharacterControl character)
    {
        return enemyTypeId.Contains(character.characterTypeId);
    }
}
