using System.Collections;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    [SerializeField]
    private float reloadTime;

    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private Arrow currentArrow;

    public static bool isEquipped = true;

    private bool isReloading;

    void Awake()
    {
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        isReloading = false;
    }

    public void Reload()
    {
        if (isReloading || currentArrow != null) return;
        isReloading = true;
        StartCoroutine(ReloadAfterTime());
    }

    private IEnumerator ReloadAfterTime()
    {
        yield return new WaitForSeconds(reloadTime);
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        isReloading = false;
    }

    public void Fire(float firePower)
    {
        if (isReloading || currentArrow == null) return;
        var force = spawnPoint.TransformDirection(Vector3.up * firePower);
        currentArrow.Fly(force);
        currentArrow = null;
        Reload();
    }

    public bool IsReady()
    {
        return (!isReloading && currentArrow != null);
    }
}
