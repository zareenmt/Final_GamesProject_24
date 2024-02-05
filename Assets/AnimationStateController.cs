using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    public Animator animator;

    public int isWalkingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool wPressed = Input.GetKey("w");
        if (wPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash,true);
        }

        if (!wPressed && isWalking)
        {
            animator.SetBool(isWalkingHash,false);
        }
        
    }
}
