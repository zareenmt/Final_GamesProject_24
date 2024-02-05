using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_StateManager : MonoBehaviour
{
    NPC_BaseState currentState;
    public NPC_PatrolState patrolState = new NPC_PatrolState();
    public NPC_ChaseState chaseState = new NPC_ChaseState();
    
    void Start()
    {
        currentState = patrolState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(NPC_BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
