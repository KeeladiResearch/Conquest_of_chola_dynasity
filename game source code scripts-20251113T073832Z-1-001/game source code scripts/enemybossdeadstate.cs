using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybossdeadstate : enemybossbasestate
{
    public enemybossdeadstate(enemybossstatemeachine  stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Ragdoll.toggleragdoll(true);
        stateMachine.Weapon.gameObject.SetActive(false);
        GameObject.Destroy(stateMachine.Target);
    }

    public override void stay(float deltaTime) { }

    public override void Exit() { }
}

