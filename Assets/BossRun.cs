using System.Collections;
using System.Collections.Generic;
using Assets.HeroEditor4D.Common.Scripts.CharacterScripts;
using Assets.HeroEditor4D.Common.Scripts.Enums;
using UnityEngine;

using static UnityEngine.RuleTile.TilingRuleOutput;

public class BossRun : StateMachineBehaviour


{
    UnityEngine.Transform player; // Explicitly specifying the UnityEngine.Transform

    Rigidbody2D rb;
    Boss boss;
    public Character4D Character;
    public float attackRange = 3f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();


        Character.AnimationManager.SetState(CharacterState.Run);


        Character.SetDirection(Vector2.down);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // boss.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, player.position.y); // Assuming z = 0 in a 2D space
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, 0.2f * Time.fixedDeltaTime);
        rb.MovePosition(newPos);


        if ( Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }


       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }


}
