using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    string creator;
    public Vector3 direction;
    float bulletLifetime = 10.0f;
    float heading;
    EnemyAttacked ea;
    void Start ()
    {
        
    }

    void Update()
    {
        // ta liczba to speed
        transform.Translate(direction * 1000 * Time.deltaTime);

        //transform.rotation = Quaternion.Euler(0, 0, 90);
        bulletLifetime -= Time.deltaTime;
        if (bulletLifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
	
    public void setVals (Vector3 dir, string name)
    {
        direction = dir;
        creator = name;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            ea = coll.gameObject.GetComponent<EnemyAttacked>();
            ea.killBullet();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
