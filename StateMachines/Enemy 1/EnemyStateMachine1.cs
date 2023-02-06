using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine1 : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }

    [field: SerializeField] public CharacterController Controller { get; private set; }

    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }

    [field: SerializeField] public NavMeshAgent Agent { get; private set; }

    [field: SerializeField] public WeaponDamage Weapon { get; private set; }


    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; } 

    [field: SerializeField] public float PlayerChasingRange { get; private set; }

    [field: SerializeField] public float AttackRange { get; private set; }

    [field: SerializeField] public int AttackDamage { get; private set; }

    [field: SerializeField] public int AttackKnockback { get; private set; }

    [field: SerializeField] public Heath Health { get; private set; }

    [field: SerializeField] public Target Target { get; private set; }

    //[field: SerializeField] public Rigidbody bulletPrefab { get; private set; }

    //[field: SerializeField] public float shootSpeed { get; private set; }

    //[field: SerializeField] public float lastAttackTime  { get; private set; }

    //[field: SerializeField] public float fireRate { get; private set; }


    private Animator anim { get;  set; }

    public Heath Player { get; private set; }
    private void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Heath>();

        Agent.updatePosition = true;
        Agent.updateRotation = true;
        
        SwitchState(new EnemyIdleState1(this));


        


    }

    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }

    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new EnemyImpactState1(this));
    }

    private void HandleDie()
    {
        SwitchState(new EnemyDeadState1(this));
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }


   
}
