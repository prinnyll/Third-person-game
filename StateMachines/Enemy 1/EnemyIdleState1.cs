using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState1 : EnemyBaseState1
{

    private readonly int LocomotionHash = Animator.StringToHash("Locomotion");

    private readonly int SpeedHash = Animator.StringToHash("Speed");

    private const float CrossFadeDuration = 1.0f;

    private const float AnimatorDampTime = 0.1f;

    public EnemyIdleState1(EnemyStateMachine1 stateMachine) : base(stateMachine) { }

  

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(LocomotionHash, CrossFadeDuration);
        
    }


    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        if (IsInChaseRange())
        {
            stateMachine.SwitchState(new EnemyChasingState1(stateMachine));
            return;
        }

        stateMachine.Animator.SetFloat(SpeedHash, 0f, AnimatorDampTime, deltaTime);
    }

    public override void Exit()
    { }
}
