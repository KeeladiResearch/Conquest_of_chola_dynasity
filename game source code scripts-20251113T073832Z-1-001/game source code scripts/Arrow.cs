using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody rb;
    public int damage;
    public int knockback;
    public Vector3 offset;
    [SerializeField] private ParticleSystem blood;
    public float time = 10f;
    public float times = 5;

    BoxCollider bx;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        
        Destroy(this.gameObject, time);
    }


    private void Update()
    {
        

       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag !="Player")
        {
            rb.isKinematic = true;
            
            gameObject.transform.parent = collision.transform;
           

        

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            ContactPoint contact = collision.contacts[0];
           transform.position = contact.point;
         
         gameObject.transform.position = collision.transform.position;
           
        }

        

        if (collision.collider.TryGetComponent<health>(out health health))
        {
            health.dealdamage(damage);
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.collider.CompareTag("solider"))
        {
            time = 10;
            Instantiate(blood, collision.transform.position + offset, transform.rotation);
           
        }
        if (collision.collider.TryGetComponent<forcereciver>(out forcereciver forceReceiver))
        {
            Vector3 direction = (collision.transform.position - transform.position).normalized;
            forceReceiver.Addforce(direction * knockback);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "enemy")
        {
            gameObject.SetActive(false);
        }
        else { 
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
