using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_ChaseState : NPC_BaseState
{
    private NPC_Attributes reference;
    private FieldOfView fov;
    private Transform target;
    private GameObject playerRef;
    private float speed = 2;
    public override void EnterState(NPC_StateManager npc)
    {
        reference = npc.GetComponent<NPC_Attributes>();
        fov = npc.GetComponent<FieldOfView>();
        playerRef = GameObject.FindGameObjectWithTag("Player");
        target = playerRef.transform;
        reference.animator.SetBool(reference.isWalkingHash,false);
        reference.animator.SetBool(reference.playerSpotHash,true);
    }

    public override void UpdateState(NPC_StateManager npc)
    {
        npc.transform.position = Vector3.MoveTowards(npc.transform.position, target.position, speed * Time.deltaTime);
        if (!fov.playerSpotted)
        {
            reference.animator.SetBool(reference.playerSpotHash,false);
            npc.SwitchState(npc.patrolState);
        }

    }

    public override void OnCollisionEnter(NPC_StateManager npc)
    {
        
    }
}
