using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class NPC_PatrolState : NPC_BaseState
{
    private NPC_Attributes reference;
    private FieldOfView fov;
    public override void EnterState(NPC_StateManager npc)
    {
        reference = npc.GetComponent<NPC_Attributes>();
        fov = npc.GetComponent<FieldOfView>();

    }

    public override void UpdateState(NPC_StateManager npc)
    {
        reference.animator.SetBool(reference.isWalkingHash,true);
        if (fov.playerSpotted)
        {
            reference.animator.SetBool(reference.isWalkingHash,false);
            npc.SwitchState(npc.chaseState);
        }

        if (!reference.nav.pathPending && reference.nav.remainingDistance < 0.5f)
        {
            if (reference.points.Length == 0)
            {
                reference.animator.SetBool(reference.isWalkingHash,false);
                return;
            }
            reference.nav.destination = reference.points[reference.destPoint].position;
            reference.destPoint = (reference.destPoint + 1) % reference.points.Length;
        }
    }
    public override void OnCollisionEnter(NPC_StateManager npc)
    {
        
    }
}
