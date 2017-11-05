using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public Transform player;
    public int maxAmmo = 30;
    private int currentAmmoAmount;

    void Start()
    {
        currentAmmoAmount = maxAmmo;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && currentAmmoAmount > 0)
        {
            Instantiate(bullet,( bulletSpawnPoint.position + (1 * bulletSpawnPoint.forward)), bulletSpawnPoint.rotation);
           // Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            currentAmmoAmount--;
        }
    }
}
