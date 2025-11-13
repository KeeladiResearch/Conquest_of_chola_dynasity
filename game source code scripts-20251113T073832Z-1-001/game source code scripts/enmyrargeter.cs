using System.Collections.Generic;
using UnityEngine;

public class enmyrargeter : MonoBehaviour
{

    [field: SerializeField] public List<solidertarget> soldierTargets;
    [field: SerializeField] public List<health> soliderh;
   [field : SerializeField] public solidertarget CurrentTarget { get; private set; }
   [field : SerializeField] public health currenthealth { get; private set; }


    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<solidertarget>(out solidertarget target)) { return; }
        if (!other.TryGetComponent<health>(out health soliderhealth)) { return; }


        soldierTargets.Add(target);
        soliderh.Add(soliderhealth);
        target.ondestroy += RemoveTarget;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<solidertarget>(out solidertarget target)) { return; }
        if (!other.TryGetComponent<health>(out health soilderhealth)) { return; }

        RemoveTarget(target);
        removehealth(soilderhealth);
    }
    private void RemoveTarget(solidertarget target)
    {
        if (CurrentTarget == target)
        {
           
            CurrentTarget = null;
        }
      

        target.ondestroy -= RemoveTarget;
        soldierTargets.Remove(target);
    }

    private void removehealth(health soliderhealth)
    {
        if(currenthealth == soliderhealth)
        {
            currenthealth = null;
        }
      
        soliderh.Remove(soliderhealth);
    }


    public void cancelcurrenthealth()
    {
        if (currenthealth.isdead)
        {


            RemoveTarget(CurrentTarget);
            removehealth(currenthealth);
            currenthealth = null;
            CurrentTarget = null;
        }
    }


    
    /* public void UpdateClosestSoldierTarget()
     {
         float closestDist = float.MaxValue;
         Transform closest = null;
         health closestHealth = null;

         foreach (Transform soldier in soldierTargets)
         {
             if (soldier == null) continue;


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
        // soliderhealth = closestHealth;
     }
    */
    /* public bool SelectTarget()
     {
         if (soldierTargets.Count == 0) { return false; }

          solidertarget closestTarget = null;
         float closestTargetDistance = Mathf.Infinity;

         foreach (solidertarget target in soldierTargets)
         {
             float dist = Vector3.Distance(transform.position, target.transform.position);




             if (dist < closestTargetDistance)
             {
                 closestTarget = target;
                 closestTargetDistance = dist;
             }
         }

         if (closestTarget == null) { return false; }

         CurrentTarget = closestTarget;


         return true;
     }
    */


    private void Update()
    {
      
        selecttarget();
        selecthealth();
    }
    public void selecttarget()
    {
        float closestDistance = float.MaxValue;
        solidertarget closest = null;
         

        foreach (solidertarget target in soldierTargets)
        {
            if (target == null || target.isdead) continue;

            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                
                closestDistance = distance;
                closest = target;
            }
        }

        CurrentTarget = closest;
    }

    public void selecthealth()
    {
        float closestDistance = float.MaxValue;
        health closest = null;


        foreach (health shealth in soliderh)
        {
           

            float distance = Vector3.Distance(transform.position, shealth.transform.position);
            if (distance < closestDistance)
            {

                closestDistance = distance;
                closest = shealth;
            }
        }

       currenthealth = closest;
    }

}
