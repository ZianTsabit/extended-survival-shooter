using System.Collections;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    [SerializeField]
    private Arrow arrowPrefab;

    [SerializeField]
    private Transform spawnPoint;

    private Arrow currentArrow;

    public static bool isEquipped = false;

    public void Fire(float firePower)
    {
        currentArrow = Instantiate(arrowPrefab, spawnPoint);
        currentArrow.transform.localPosition = Vector3.zero;
        var force = spawnPoint.TransformDirection(Vector3.up * firePower);
        currentArrow.Fly(force);
        currentArrow = null;
    }
}
