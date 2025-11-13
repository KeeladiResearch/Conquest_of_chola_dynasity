using System.Diagnostics;
using UnityEngine;


public class StateMachine
{
    public State currentState;

    public void Initialize(State startingState)
    {
        if (startingState == null)
        {
            UnityEngine.Debug.LogError("❌ Starting state is NULL in Initialize()!");
            return;
        }

        UnityEngine.Debug.Log("✅ Initializing StateMachine with: " + startingState.GetType().Name);
        currentState = startingState;

        if (currentState == null)
        {
            UnityEngine.Debug.LogError("❌ currentState is STILL NULL after assignment!");
            return;
        }

        currentState.Enter();
    }



    public void ChangeState(State newState)
    {
        if (newState == null)
        {
            UnityEngine.Debug.LogError("StateMachine.ChangeState: newState is NULL!");
            return;
        }

        if (currentState != null)
        {
            currentState.Exit();
        }

        UnityEngine.Debug.Log("Changing state to: " + newState.GetType().Name);
        currentState = newState;
        newState.Enter();
    }



}