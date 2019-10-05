using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttacks : MonoBehaviour
{
    private ChangeCombatMode combatMode;
    private Animator animator;

    private void Awake()
    {
        combatMode = GetComponent<ChangeCombatMode>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(combatMode.getHeavyModeStatus)
        {
            if (Input.GetButton("Fire2"))
            {
                animator.SetBool("isMeleeing", true);
                //Debug.Log("Melee!");
            }
            else
            {
                animator.SetBool("isMeleeing", false);
            }
        }
    }
}
