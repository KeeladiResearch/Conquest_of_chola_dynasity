using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class forcereciver : MonoBehaviour
{
    [SerializeField]CharacterController characterController;
    Vector3 impact;
    private float velocityreciver;
    private Vector3 dmpingvelocity;
    [SerializeField] private float drag = 0.3f;
    public Vector3 movement => impact+Vector3.up * velocityreciver;
   [SerializeField] private NavMeshAgent agent;
    void Update()
    {
        if( velocityreciver <=0 && characterController.isGrounded)
        {
            velocityreciver = Physics.gravity.y*Time.deltaTime;
            }
        else
        {
            velocityreciver += Physics.gravity.y * Time.deltaTime;
        }
        
        impact = Vector3.SmoothDamp(impact, Vector3.zero,ref dmpingvelocity,drag);
        if (agent != null)
        {
            if (impact.sqrMagnitude < 0.2f*0.2f)
            {
                impact = Vector3.zero;
                agent.enabled = true;
            }
        }
    }
    public void Addforce(Vector3 force)
    {
        impact += force;
        if (agent != null)
        {
           agent.enabled = false;   
        }
    }

    public void jump(float jumpforce)
    {
        velocityreciver += jumpforce;
    }
}
