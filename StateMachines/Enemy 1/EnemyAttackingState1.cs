using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackingState1 : EnemyBaseState1
{
    //private readonly int AttackHash = Animator.StringToHash("Attack1");

    private const float TransitionDuration = 0.1f;

    

    public EnemyAttackingState1(EnemyStateMachine1 stateMachine) : base(stateMachine) { }

    public override void Enter()
    {


        stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);

        //AttackHash.SetInteger("AttackIndex", Random.Range(0, 3));
        //stateMachine.Animator.CrossFadeInFixedTime(AttackHash, TransitionDuration);


        //stateMachine.Animator.CrossFadeInFixedTime(("Attack"), TransitionDuration);

        //stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
        //int animName = Random.Range(0, stateMachine.ATKAnimationList.Length);
        //Playing(stateMachine.ATKAnimationList[animName]);


        //if (stateMachine.AttackRange >= 5)
        //{

        //    stateMachine.Animator.CrossFadeInFixedTime(("Attack1"), TransitionDuration);
        //}
        //else if (stateMachine.AttackRange >= 4)
        //{
        //    stateMachine.Animator.CrossFadeInFixedTime(("Attack2"), TransitionDuration);
        //}
        //else if (stateMachine.AttackRange >= 3)
        //{
        //    stateMachine.Animator.CrossFadeInFixedTime(("Attack3"), TransitionDuration);
        //}
        AttackTarget();
       
    }


    public override void Tick(float deltaTime)
    {
        FacePlayer();
        

        if (GetNormalizedTime(stateMachine.Animator) >= 1f)
        {

            stateMachine.SwitchState(new EnemyChasingState1(stateMachine));
        }
      


    }

    

    public override void Exit()
    {
       
    }
   void AttackTarget()
    {
       
            stateMachine.Weapon.SetAttack(stateMachine.AttackDamage, stateMachine.AttackKnockback);
           
            stateMachine.Animator.SetInteger("AttackIndex", Random.Range(0, 3));
            stateMachine.Animator.SetTrigger("Attack");
      


        //stateMachine.Animator.CrossFadeInFixedTime(("Attack1_1"), TransitionDuration);
        //stateMachine.Animator.CrossFadeInFixedTime(("Attack2"), TransitionDuration);
        //stateMachine.Animator.CrossFadeInFixedTime(("Attack3"), TransitionDuration);

    }


   



}
