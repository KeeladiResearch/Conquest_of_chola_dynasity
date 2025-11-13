using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class enemybossstatemeachine : realstatemeachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public forcereciver  ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public weapondamage Weapon { get; private set; }
    [field: SerializeField] public health Health { get; private set; }
    [field: SerializeField] public target Target { get; private set; }
    [field: SerializeField] public ragadol Ragdoll { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
  
   

    [field: SerializeField] public bossattack[] bossattack;

 [field: SerializeField]   public GameObject Player { get; private set; }

    private void Start()
    {
       Health = Player.GetComponent<health>();

        Agent.updatePosition = false;
        Agent.updateRotation = false;

        switchstate(new enemybossidlestatemeachine(this));
    }

    private void OnEnable()
    {
        Health.ontakedamage += HandleTakeDamage;
        Health.ondie += HandleDie;
    }

    private void OnDisable()
    {
        Health.ontakedamage -= HandleTakeDamage;
        Health.ondie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        switchstate(new enemybossimpactstate(this));
    }

    private void HandleDie()
    {
        switchstate(new enemybossdeadstate(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
}
