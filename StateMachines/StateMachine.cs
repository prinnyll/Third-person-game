using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class StateMachine : MonoBehaviour
{

    
    private State currentState;

    public void SwitchState(State newState)
    {
        //exit the current state
        currentState?.Exit();
        //switch to a new state
        currentState = newState;
        //enter the new state
        currentState?.Enter();
        
    }

    private void Update()
    {
        //? or //if(currentState != null)
        //Null-conditional operators ?
        //?=variable is null and if it isn't null, it will call the tick method on it
        currentState?.Tick(Time.deltaTime);  
    }
}
