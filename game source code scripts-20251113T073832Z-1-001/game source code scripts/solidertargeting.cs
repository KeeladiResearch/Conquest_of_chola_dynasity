using System.Collections.Generic;
using UnityEngine;

public class solidertargeting : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] public List<enemytarget> enemytargets;
    [SerializeField] public List<health> enemyhealth;

    [field: SerializeField] public health currenthealth {  get;private set; }
    [field: SerializeField] public enemytarget currentenmytarget { get; private set; }



    private void Update()
    {
        selecthealth();
        selecttarget();
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(!other.TryGetComponent<enemytarget>(out enemytarget enemytargert)) {  return; }
        if(!other.TryGetComponent<health>(out health enemyhealths)) {  return; }

        this.enemytargets.Add(enemytargert);
        this.enemyhealth.Add(enemyhealths);

        enemytargert.ondestroy += RemoveTarget;

    }


    private void OnTriggerExit(Collider other)
    {


        if (!other.TryGetComponent<enemytarget>(out enemytarget enemytargert)) { return; }
        if (!other.TryGetComponent<health>(out health enemyhealths)) { return; }

        this.enemytargets.Add(enemytargert);
        this.enemyhealth.Add(enemyhealths);


        RemoveTarget(enemytargert);
        removehealth(enemyhealths);



    }

    private void RemoveTarget(enemytarget target)
    {
        if (currentenmytarget == target)
        {

            currentenmytarget = null;
        }


        target.ondestroy -= RemoveTarget;
        enemytargets.Remove(target);
    }

    private void removehealth(health soliderhealth)
    {
        if (currenthealth == soliderhealth)
        {
            currenthealth = null;
        }

        enemyhealth.Remove(soliderhealth);
    }


    public void cancelcurrenthealth()
    {
        if (currenthealth.isdead)
        {


            RemoveTarget(currentenmytarget);
            removehealth(currenthealth);
            currenthealth = null;
            currentenmytarget = null;
        }
    }

    public void selecttarget()
    {
        float closestDistance = float.MaxValue;
        enemytarget closest = null;


        foreach (enemytarget target in enemytargets)
        {


            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {

                closestDistance = distance;
                closest = target;
            }
        }

        currentenmytarget = closest;
    }

    public void selecthealth()
    {
        float closestDistance = float.MaxValue;
        health closest = null;


        foreach (health shealth in enemyhealth)
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
