using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragadol : MonoBehaviour
{
    [SerializeField] CharacterController characterController;

    [SerializeField] Animator animator;

    private Collider[] colliders;
    
    private Rigidbody[] rigidbodies;


    private void Start()
    {
        colliders = GetComponentsInChildren<Collider>(true);
        rigidbodies = GetComponentsInChildren<Rigidbody>(true);

        toggleragdoll(false);
    }

    public void toggleragdoll(bool isragadoll)
    {
        foreach (Collider collider in colliders) {

            if (collider.gameObject.CompareTag("ragedol"))
            {
                collider.enabled = isragadoll;
            }
        }  
        foreach (Rigidbody rigidbody in rigidbodies) {

            if (rigidbody.gameObject.CompareTag("ragedol"))
            {
                rigidbody.isKinematic = !isragadoll;
                rigidbody.useGravity = isragadoll;
            }
        }
        characterController.enabled =!isragadoll;
        animator.enabled = !isragadoll;
    }
}
