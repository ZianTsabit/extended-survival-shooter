using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private Rigidbody rigid;

    [SerializeField]
    private TrailRenderer trail;

    private bool didHit;

    public void Fly(Vector3 force)
    {
        trail.enabled = true;
        rigid.isKinematic = false;
        rigid.AddForce(force, ForceMode.Impulse);
        transform.SetParent(null);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player")
        {
            if (didHit) return;
            didHit = true;

            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage + WeaponHolder.bonusDamage, transform.position);
            }

            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
            rigid.isKinematic = true;
            transform.SetParent(collision.transform);
        }
    }
}