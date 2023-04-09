using UnityEngine;
using UnityEngine.UI;

public class BowController : MonoBehaviour
{
    [SerializeField]
    private Text firePowerText;

    [SerializeField]
    private PlayerBow bow;

    [SerializeField]
    private float maxFirePower;

    [SerializeField]
    private float firePowerSpeed;

    private float firePower;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private float minRotation;

    [SerializeField]
    private float maxRotation;

    private bool fire;

    void Update()
    {
        bow.transform.localScale = Vector3.one;
        

        if (Input.GetMouseButtonDown(0))
        {
            fire = true;
        }

        if (fire && firePower < maxFirePower)
        {
            firePower += Time.deltaTime * firePowerSpeed;
        }

        if (fire && Input.GetMouseButtonUp(0))
        {
            bow.Fire(firePower);
            firePower = 0;
            fire = false;
        }

        if (fire)
        {
            firePowerText.text = "FirePower: " + firePower.ToString();
        }
    }
}
