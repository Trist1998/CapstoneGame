using System.Linq;
using UnityEngine;
public class AbstractCharacterControl: MonoBehaviour
{
    public int characterTypeId;
    public int[] enemyTypeId;

    public bool isCharacterEnemy(int typeId)
    {
        return enemyTypeId.Contains(typeId);
    }
}
