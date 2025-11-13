using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class playerweapondamage : MonoBehaviour
{
    [SerializeField] private Collider myCollider;
    [SerializeField] private ParticleSystem blood;
    [SerializeField] float  offset_y;
   
    private int damage;
    private float knockback;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<health>(out health health))
            {
                health.dealdamage(damage);
            }
            Instantiate(blood, other.gameObject.transform.position+new Vector3(0,offset_y,0), other.transform.rotation);
            if (other.TryGetComponent<forcereciver>(out forcereciver forceReceiver))
            {
                Vector3 direction = (other.transform.position - myCollider.transform.position).normalized;
                forceReceiver.Addforce(direction * knockback);
            }
        }
    }

    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
