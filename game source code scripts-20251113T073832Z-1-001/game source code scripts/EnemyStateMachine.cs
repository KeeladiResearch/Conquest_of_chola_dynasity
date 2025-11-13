using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyStateMachine : realstatemeachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public forcereciver ForceReceiver { get; private set; }
    [field: SerializeField] public NavMeshAgent Agent { get; private set; }
    [field: SerializeField] public weapondamage Weapon { get; private set; }

    [field: SerializeField] public health soliderhealth { get; private set; }
    [field: SerializeField] public target Target { get; private set; }
    [field: SerializeField] public ragadol Ragdoll { get; private set; }

    [field: SerializeField] public float MovementSpeed { get; private set; }
    [field: SerializeField] public float PlayerChasingRange { get; private set; }
    [field: SerializeField] public float soliderChasingRange { get; private set; }
    [field: SerializeField] public float AttackRange { get; private set; }
    [field: SerializeField] public float soliderAttackRange { get; private set; }
    [field: SerializeField] public int AttackDamage { get; private set; }
    [field: SerializeField] public int AttackKnockback { get; private set; }

    [field: SerializeField] public float attackCooldown { get; set; }

    [field: SerializeField] public GameObject Player { get; private set; }
    [field: SerializeField] public GameObject[] droping { get; private set; }



    [field: SerializeField] public List<Transform> soldierTargets;
    [field: SerializeField] public Transform CurrentTarget;

    [field: SerializeField] public enmyrargeter enmyrargeter { get; private set; }
    [field: SerializeField] public health Health { get; private set; }

    [SerializeField] public health ourhealth;

    [SerializeField] public enemymanager enemymanager;

     public static int deathpoints = 0;
    [field: SerializeField] public  Text deathtext;
    private void Start()
    {
        Health = Player.GetComponent<health>();

        ourhealth = gameObject.GetComponent<health>();
        //soliderhealth = enemy.GetComponent<health>();

        Agent.updatePosition = false;
        Agent.updateRotation = false;
        switchstate(new EnemyIdleState(this));

    }
   public int addpoints()
    {
        return deathpoints += 10;
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
        switchstate(new EnemyImpactState(this));
    }

    private void HandleDie()
    {
        switchstate(new EnemyDeadState(this));
    }

    public void spawning()
    {
        int randomvalue = Random.Range(0,droping.Length);

        Instantiate(droping[randomvalue], transform.position, transform.rotation);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, PlayerChasingRange);
        Gizmos.DrawWireSphere(transform.position, soliderChasingRange);
    }


    public void UpdateClosestSoldierTarget()
    {
        float closestDist = float.MaxValue;
        Transform closest = null;
        health closestHealth = null;

        foreach (Transform soldier in soldierTargets)
        {
            if (soldier == null) continue;

            health health = soldier.GetComponent<health>();
            if (health != null && !health.isdead)
            {
                float dist = Vector3.Distance(transform.position, soldier.position);
                if (dist < closestDist)
                {
                    closestDist = dist;
                    closest = soldier;
                    closestHealth = health;
                }
            }
        }

        CurrentTarget = closest;
        soliderhealth = closestHealth;
    }

}
