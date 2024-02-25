using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_IdleState : NPC_BaseState
{
    private NPC_Attributes reference;
    public override void EnterState(NPC_StateManager npc)
    {
        reference = npc.GetComponent<NPC_Attributes>();
        reference.animator.SetBool(reference.combatHash, true);
    }

    public override void UpdateState(NPC_StateManager npc)
    {
        
    }
    public override void OnCollisionEnter(NPC_StateManager npc)
    {
        
    }
}
