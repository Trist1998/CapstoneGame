using System.Linq;
using UnityEngine;
public class AbstractCharacterControl: WorldObject
{
    public int characterTypeId;
    public int[] enemyTypeId;
    public Animator animator;
    private RagdollController ragdollController;
    protected void Start()
    {
        base.Start();
        if (animator == null) animator = GetComponent<Animator>();
        ragdollController = gameObject.AddComponent<RagdollController>();
        ragdollController.animator = animator;
        unragdoll();
        

    }
    
    public bool isCharacterEnemy(AbstractCharacterControl character)
    {
        return enemyTypeId.Contains(character.characterTypeId);
    }
    
    public virtual void unragdoll()
    {
        ragdollController.unragdoll();
    }

    public virtual void ragdoll()
    {
        ragdollController.ragdoll();
    }
    
}
