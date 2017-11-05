using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class WeaponAttack : MonoBehaviour
{
    public GameObject bullet, curWeapon, ShootButton;
    public bool gun = false;
    bool changingWeapon = false;
    float timer = 0.1f, timerReset = 0.1f, weaponChange = 0.5f;
    public Transform bulletSpawnPoint;
    private PlayerMovement pm;
    private ShootButton sb;

    void Start()
    {
        sb = GameObject.FindGameObjectWithTag("shootbutton").GetComponent<ShootButton>();
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (sb.isButtonClicled == true && timer <=0)
        {
            attack();
        }
        if(changingWeapon == true)
        {
            weaponChange -= Time.deltaTime;
            if(weaponChange < 0)
            {
                changingWeapon = false;
            }
        }
    }

    public void setWeapon(GameObject cur, string weaponName, float fireRate, bool gun)
    {
        changingWeapon = true;
        curWeapon = cur;
        this.gun = gun;
        timerReset = fireRate;
        timer = timerReset;
    }

    public void attack()
    {
        //broń palna
        if (gun == true)
        {
            Bullet bl = bullet.GetComponent<Bullet>();
            Vector3 bulletDir;
            bulletDir.x = Vector2.right.x;
            bulletDir.y = Vector2.right.y;
            bulletDir.z = 0;
            bl.setVals(bulletDir, "player");;
            Instantiate(bullet, bulletSpawnPoint.transform.position, bulletSpawnPoint.rotation);
            timer = timerReset;
        }
        //meele
        else
        {
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.up.x*100, transform.up.y*100));
            Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.up.x*100, transform.up.y*100), Color.green);

            if(ray.collider != null)
            {
                if(ray.collider.gameObject.tag == "enemy")
                {
                    EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked>();
                    ea.killMeele();
                }
            }
            
            /*if(curWeapon == null && ray.collider.gameObject.tag == "enemy")
             {

             }*/

        }
    }

    public GameObject getCur()
    {
        return curWeapon;
    }

    public void dropWeapon()
    {
        curWeapon.transform.position = this.transform.position;
        curWeapon.SetActive(true);
        setWeapon(null, "", 0.5f, false);
    }
}

