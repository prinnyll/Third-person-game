using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");

    private Vector3 momentum;

    private const float CrossFadeDuration = 0.1f;

    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f;

        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);

        stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
    }

    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

        
            if (stateMachine.Controller.isGrounded)
            {
                ReturnToLocomotion();
            }

        FaceTarget();
    }

    public override void Exit()
    {
        stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
    }

    private void HandleLedgeDetect(Vector3 ledgeForward)
    {
        stateMachine.SwitchState(new PlayerHangingState(stateMachine, ledgeForward));
    }


}
