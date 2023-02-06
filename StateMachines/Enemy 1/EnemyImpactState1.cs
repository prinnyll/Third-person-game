using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyImpactState1 : EnemyBaseState1
{
    private readonly int ImpactHash = Animator.StringToHash("Impact");

    private const float CrossFadeDuration = 0.1f;

    private float duration = 1f;

    public EnemyImpactState1(EnemyStateMachine1 stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(ImpactHash, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);

        duration -= deltaTime;

        if (duration <= 0f)
        {
            stateMachine.SwitchState(new EnemyIdleState1(stateMachine));
        }
    }

    public override void Exit() { }

}
