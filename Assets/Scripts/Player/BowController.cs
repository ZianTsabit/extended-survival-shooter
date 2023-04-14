using UnityEngine;
using UnityEngine.UI;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private Slider chargeBarSlider;

    [SerializeField]
    private PlayerBow bow;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    private bool fire;

    GameObject player;

    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        chargeBarSlider.minValue = 0;
        chargeBarSlider.maxValue = maxFirePower;
    }

    void Update()
    {
        bow.transform.localScale = Vector3.one;


        if (Input.GetMouseButtonDown(1))
        {
            fire = true;
            anim.SetBool("isDrawing", true);
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

        chargeBarSlider.value = firePower;

        if (fire && Input.GetMouseButtonUp(1))
        {
            bow.Fire(firePower);
            firePower = 0;
            fire = false;
            anim.SetBool("isDrawing", false);
        }
    }
}
