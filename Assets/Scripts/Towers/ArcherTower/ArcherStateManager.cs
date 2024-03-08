using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class ArcherStateManager : MonoBehaviour
{
    public ArcherState currentState;
    void Update()
    {
        RunStateMachine();

    }

    private void RunStateMachine()
    {
        ArcherState nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }

    private void SwitchToNextState(ArcherState nextState)
    {
        currentState = nextState;
    }
}
