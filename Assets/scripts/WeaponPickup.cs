using UnityEngine;
using System.Collections;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName;
    public float fireRate;
    WeaponAttack wa;
    public bool gun;
    bool isPlayerOut = true;

	void Start ()
    {
        wa = GameObject.FindGameObjectWithTag("player").GetComponent<WeaponAttack>();
	}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "player" && isPlayerOut == true)
        {
            if (wa.getCur() != null)
            {
                wa.dropWeapon();
            }
            wa.setWeapon(this.gameObject, weaponName, fireRate, gun);
            this.gameObject.SetActive(false);
            isPlayerOut = false;
        }  
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        isPlayerOut = true;
    }
}
