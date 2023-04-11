using UnityEngine;

public class PlayerShotgun : MonoBehaviour
{
    // public int damagePerShot = Mathf.Lerp(30, 10, distance / maxDistance);
    public static int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public int bulletSpread = 1;
    public static bool isEquipped = false;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;

    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0 && !ShopScript.afterQuestShopping)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
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
        gunLine.positionCount = 4 * bulletSpread - 2;

        for (int i = 0; i < gunLine.positionCount; i += 2)
        {
            gunLine.SetPosition(i, transform.position);

            int factor = ((i / 2) % 2 == 0 ? -1 : 1) * (((i / 2) + 1) / 2);
            float yRot = 15 * factor;
            Quaternion q = Quaternion.AngleAxis(yRot, Vector3.up);
            shootRay.origin = transform.position;
            shootRay.direction = q * transform.forward;

            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot + WeaponHolder.bonusDamage, shootHit.point);
                }

                gunLine.SetPosition(i + 1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(i + 1, shootRay.origin + shootRay.direction * range);
            }
        }
    }
}