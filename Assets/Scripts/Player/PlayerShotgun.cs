using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    public static int damagePerShot = 10;
    public float timeBetweenBullets = 0.5f;
    public float range = 10f;
    public int bulletCount = 10;
    public float spreadRadius = 0.2f;

    public static bool isEquipped = false;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;

    Animator anim;
    GameObject player;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !ShopScript.afterQuestShopping)
        {
            anim.SetBool("isShooting", true);
            Invoke("Shoot", 0.2f);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("isShooting", false);
        }

        if (timer >= timeBetweenBullets * 0.2f)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.positionCount = 2 * bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            Vector3 direction = transform.forward + Random.insideUnitSphere * spreadRadius;
            direction.Normalize();

            Vector3 origin = transform.position;
            gunLine.SetPosition(2 * i, origin);

            if (Physics.Raycast(origin, direction, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot + WeaponHolder.bonusDamage, shootHit.point);
                }
                gunLine.SetPosition(2 * i + 1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(2 * i + 1, origin + direction * range);
            }
        }
    }
}
