using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    [SerializeField] private CinemachineTargetGroup cineTargetGroup;

    private Camera maincamera;

    private List<Target> targets = new List<Target>();

    public Target CurrentTarget { get; private set; }

    private void Start()
    {
        maincamera = Camera.main;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if the other thing does have the component target, then Add the Target
        if(!other.TryGetComponent<Target>(out Target target)) { return; }

        targets.Add(target);
          target.OnDestroyed += RemoveTarget;
        
        //old ways
        //Target target = other.GetComponent<Target>();

        //if(target == null) { return; }

        //targets.Add(target);
    }

    private void OnTriggerExit(Collider other)
    {
        //if the other thing does have the component target, then remove the Target
        if (!other.TryGetComponent<Target>(out Target target)) { return;}
        

        RemoveTarget(target);
        
        //old ways
        //Target target = other.GetComponent<Target>();

        //if (target == null) { return; }

        //targets.Remove(target);
    }

    public bool SelectTarget()
    {
        
        if(targets.Count == 0) { return false; } //if no targets return false

        Target closestTarget = null;
        float closestTargetDistannce = Mathf.Infinity;


        foreach (Target target in targets)
        {
            Vector2 viewPos = maincamera.WorldToViewportPoint(target.transform.position);

            if(!target.GetComponentInChildren<Renderer>().isVisible)
            {
                continue;
            }

            Vector2 toCenter = viewPos - new Vector2(0.5f, 0.5f);
            if(toCenter.sqrMagnitude < closestTargetDistannce)
            {
                closestTarget = target;
                closestTargetDistannce = toCenter.sqrMagnitude;
            }
        }

        if(closestTarget == null ) { return false; }


        CurrentTarget = closestTarget;
        cineTargetGroup.AddMember(CurrentTarget.transform, 1f, 2f);

        return true; //if have targets return true
    }

    public void Cancel()
    {
        if(CurrentTarget == null) { return; }

        cineTargetGroup.RemoveMember(CurrentTarget.transform);
        CurrentTarget = null;
    }

    private void RemoveTarget(Target target)
    {
        if(CurrentTarget == target)
        {
            cineTargetGroup.RemoveMember(CurrentTarget.transform);
            CurrentTarget = null;
        }

        target.OnDestroyed -= RemoveTarget;
        targets.Remove(target);
    }
}
