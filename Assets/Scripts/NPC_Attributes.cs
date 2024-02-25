using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Attributes : MonoBehaviour
{
    public Transform[] points;
    public NavMeshAgent nav;
    public int destPoint;
    public Animator animator;

    public int isWalkingHash;
    public int playerSpotHash;
    public int combatHash;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        playerSpotHash = Animator.StringToHash("PlayerSpot");
        combatHash = Animator.StringToHash("Combat");
    }
    
    void Update()
    {
        
    }
}
