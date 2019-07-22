using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractCharacterControl : MonoBehaviour
{
    public static readonly int WIZARD = 1;
    public static readonly int HUMAN = 2;
    [SerializeField]
    private int characterTypeId;
    [SerializeField]
    private List<int> enemyTypeIds;

    public bool isEnemy(int typeId)
    {
        return enemyTypeIds.Contains(typeId);
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
