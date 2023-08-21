using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class fade_death : StateMachineBehaviour
{
    private float timer = 0f; public float time;
    SpriteRenderer spriteRenderer;
    GameObject to_remove;
    Color startcolor;
    private float alpha;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        to_remove = animator.gameObject;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        startcolor = spriteRenderer.color;
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        alpha = startcolor.a *(1 - (timer / time));
        spriteRenderer.color = new Color(startcolor.r, startcolor.g, startcolor.b, alpha); 
        if(timer > time)
        {
            Destroy(to_remove);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
