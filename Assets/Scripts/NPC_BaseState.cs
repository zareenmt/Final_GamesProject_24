using UnityEngine;

public abstract class NPC_BaseState
{
    public abstract void EnterState(NPC_StateManager npc);
    public abstract void UpdateState(NPC_StateManager npc);
    public abstract void OnCollisionEnter(NPC_StateManager npc);
}
