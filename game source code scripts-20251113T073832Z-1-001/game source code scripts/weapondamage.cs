using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Crest.Spline.Spline;

public class weapondamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    private float knockback;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] float offset_y;
    private List<Collider> alreadyCollidedWith = new List<Collider>();

    private void OnEnable()
    {
        alreadyCollidedWith.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) { return; }

        if (alreadyCollidedWith.Contains(other)) { return; }

        alreadyCollidedWith.Add(other);

        if (other.TryGetComponent<health>(out health health))
        {
            health.dealdamage(damage);
        }
        if (other.gameObject.CompareTag("Player") ||other.gameObject.CompareTag("solider"))
        {
            Instantiate(blood, other.gameObject.transform.position + new Vector3(0, offset_y, 0), other.transform.rotation);
        }
        if (other.TryGetComponent<forcereciver>(out forcereciver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
            forceReceiver.Addforce(direction * knockback);
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }

}