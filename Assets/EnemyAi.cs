using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{
    GameObject player;
    public bool patrol = true, guard = false, moving = true, targetOnPlayer = false, comeback = false, rotateDir = true;
    Vector3 target;
    private Rigidbody2D rb;
    public Vector3 playerLastPos;
    RaycastHit2D ray;
    private float speed = 50.0f;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("player");
        playerLastPos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        movement();
	}

    void movement()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        Vector3 moveDir = player.transform.position - transform.position;
        ray = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(moveDir.x, moveDir.y), distance*100, 1);

        Vector3 fwt = this.transform.TransformDirection(Vector3.right);

        RaycastHit2D ray2 = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(fwt.x, fwt.y), 50, 1);

        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(fwt.x*50, fwt.y*50), Color.blue);

        if (moving == true)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (patrol == true)
        {
            speed = 50.0f;

            if (ray2.collider != null)
            {
                if (ray2.collider.gameObject.tag == "wall")
                {
                    if (rotateDir == false)
                    {
                        transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        transform.Rotate(0, 0, -90);
                    }
                }
            }
        }

    }

    public void playerDetect()
    {
        Vector3 pos = this.transform.InverseTransformPoint(player.transform.position);

        if(ray.collider !=null)
        {
            if (ray.collider.gameObject.tag == "player" && pos.x > 1.2f && Vector3.Distance(this.transform.position, player.transform.position)<9)
            {
                patrol = false;
                targetOnPlayer = true;
            }
            else if (targetOnPlayer == true)
            {
                patrol = true;
                targetOnPlayer = false;
            }
        }
    }
}
