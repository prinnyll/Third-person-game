using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerStateMachine : StateMachine
{
    //[get] anyone can read this, [private set]but only private can set it 
    [field: SerializeField]public InputReader InputReader { get;  set; }

    [field: SerializeField] public CharacterController Controller { get;  set; }

    [field: SerializeField] public Animator Animator { get;  set; }

    [field: SerializeField] public Targeter Targeter { get;  set; }

    [field: SerializeField] public ForceReceiver ForceReceiver { get;  set; }

    [field: SerializeField] public WeaponDamage Weapon { get;  set; }

    [field: SerializeField] public Heath Health { get;  set; }

    [field: SerializeField] public Ragdoll Ragdoll { get;  set; }

    [field: SerializeField] public LedgeDetector LedgeDetector { get;  set; }

    [field: SerializeField] public float FreeLookMovementSpeed { get;  set; }

    [field: SerializeField] public float TargetingMovementSpeed { get;  set; }

    [field: SerializeField] public float RotationSmoothValue { get;  set; }

    [field: SerializeField] public float DodgeDuration { get;  set; }

    [field: SerializeField] public float DodgeLength { get;  set; }


    [field: SerializeField] public float JumpForce { get;  set; }

    [field: SerializeField] public Attack[] Attacks { get;  set; }

    private PhotonView pv;

    public float PreviousDodgeTime { get; private set; } = Mathf.NegativeInfinity;
    public Transform MainCameraTransform { get; private set; }

    public Camera PlayerCamera;


    public void Start()
    {
        PlayerCamera _cameraWork = this.gameObject.GetComponent<PlayerCamera>();
      

        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
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
        SwitchState(new PlayerImpactState(this));
    }

    private void HandleDie()
    {
        SwitchState(new PlayerDeadState(this));
    }

 


}
