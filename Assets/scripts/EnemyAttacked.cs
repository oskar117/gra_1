using UnityEngine;
using System.Collections;

public class EnemyAttacked : MonoBehaviour
{
    public Sprite deadEnemy;
    SpriteRenderer sr;
    GameObject player;

	void Start ()
    {
        sr = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("player");
	}

    public void killBullet()
    {
       // Destroy(this.gameObject);
        //Instantiate(deadEnemy, this.transform.position, this.transform.rotation);
        sr.sprite = deadEnemy;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.tag = "dead";
    }
    public void killMeele()
    {
        sr.sprite = deadEnemy;
        //sr.sprite == txt udezenia
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.tag = "dead";
    }
}
