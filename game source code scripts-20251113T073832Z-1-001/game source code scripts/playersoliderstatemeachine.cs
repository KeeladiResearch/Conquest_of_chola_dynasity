using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class playersoliderstatemeachine : realstatemeachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public forcereciver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public playerweapondamage Weapon { get; private set; }
    [field: SerializeField] public health Health { get; private set; }
    [field: SerializeField] public health ourhealth { get; private set; }
    [field: SerializeField] public target Target { get; private set; }
    [field: SerializeField] public ragadol Ragdoll { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; set; }
    [field: SerializeField] public float PlayerfollowingRange { get; set; }
    [field: SerializeField] public float AttackRange { get; set; }
    [field: SerializeField] public float closestrange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public int AttackKnockback { get; private set; }
    [field: SerializeField] public inputmanager inputmanager { get; private set; }
    [field: SerializeField] public solidertargeting solidertargeting { get; private set; }
    [field: SerializeField] public GameObject player { get; private set; }
    [field: SerializeField] public bool isattack = false;

    [field: SerializeField] public float attackCooldown { get; set; }
    [field: SerializeField] public Text deathtext { get; set; }
    [field: SerializeField] public solidedrManager solidermanger { get; set; }

    private void Start()
    {
        ourhealth = gameObject.GetComponent<health>();
        Health = player.GetComponent<health>();
        Agent.updatePosition = false;
        Agent.updateRotation = false;

        switchstate(new playersolideridlestate(this));
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
        switchstate(new playersoliderimpactstate(this));
    }

    private void HandleDie()
    {
        switchstate(new playersoliderdeadstate(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
    }
}
