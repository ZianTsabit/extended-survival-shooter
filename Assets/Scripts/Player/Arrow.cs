using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private int damage;

    [SerializeField]
    private float torque;

    [SerializeField]
    private Rigidbody rigid;

    private bool didHit;

    public void Fly(Vector3 force)
    {
        rigid.isKinematic = false;
        rigid.AddForce(force, ForceMode.Impulse);
        rigid.AddTorque(transform.right * torque);
        transform.SetParent(null);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (didHit) return;
        didHit = true;

        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage + WeaponHolder.bonusDamage, transform.position);
        }

        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
        rigid.isKinematic = true;
        transform.SetParent(collider.transform);
    }
}