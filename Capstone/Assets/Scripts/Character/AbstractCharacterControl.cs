using System.Linq;
using UnityEngine;
public class AbstractCharacterControl: HealthControl
{
    public int characterTypeId;
    public int[] enemyTypeId;

    public bool isCharacterEnemy(AbstractCharacterControl character)
    {
        return enemyTypeId.Contains(character.characterTypeId);
    }
}
