using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController characterController;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    
    public void CharacterMove(float Strafe, float forward)
    {
        animator.SetFloat("Forward", forward);
        animator.SetFloat("Strafe", Strafe);
        
    }
    public void CharacterPrint(bool issprint)
    {
        animator.SetBool("Sprint", issprint);
        
    }

    public void CharacterFight()
    {
        animator.SetTrigger("fight");
    }
    public void Death()
    {
        animator.SetTrigger("Death");
    }

    public void effectFight()
    {
        animator.SetTrigger("Effect");
    }
}
