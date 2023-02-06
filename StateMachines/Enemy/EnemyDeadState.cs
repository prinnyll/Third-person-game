using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyBaseState
{
    public EnemyDeadState(EnemyStateMachine stateMachine) : base(stateMachine) { }


    public override void Enter()
    {
        // toggle ragdoll
        stateMachine.Weapon.gameObject.SetActive(false);
        stateMachine.Ragdoll.ToggleRagdoll(true);
        GameObject.Destroy(stateMachine.Target);

    }

    public override void Tick(float deltaTime) { }

    public override void Exit() { }


}
