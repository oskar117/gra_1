/*using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 rotation;
    public bool moving = false;
    public float speed = 50.0f;
    private Animator animator;

    void Start()
    {
        rotation = new Vector3(0, 0, 0);
        animator = GetComponent<Animator>() as Animator;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
            rotation = new Vector3(0, 0, 90);
            transform.eulerAngles = rotation;
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
            rotation = new Vector3(0, 0, 270);
            transform.eulerAngles = rotation;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
            rotation = new Vector3(0, 0, 180);
            transform.eulerAngles = rotation;
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
            rotation = new Vector3(0, 0, 0);
            transform.eulerAngles = rotation;
        }
        if ((Input.GetAxisRaw("Vertical") > 0) != true && (Input.GetAxisRaw("Vertical") < 0) != true && (Input.GetAxisRaw("Horizontal") > 0) != true && (Input.GetAxisRaw("Horizontal") < 0) != true)
        {
            moving = false;
        }
    }

}*/
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    private Joystick joystick;
    private Rigidbody2D rb;
    public Vector3 MoveVector;
    public Vector3 rotationVector;
    public float moveSpeed = 1.0f;
    private Animator animator;
    public float heading;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<Joystick>();
        animator = GetComponent<Animator>() as Animator;
    }
    void FixedUpdate()
    {
        MoveVector = PoolInput();
        if (MoveVector.x != 0 && MoveVector.y != 0)
        {
            rotationVector.x = MoveVector.x;
            rotationVector.y = MoveVector.y;
        }
        heading = Mathf.Atan2(rotationVector.x, rotationVector.y);
        transform.rotation = Quaternion.Euler(0f, 0f, heading * -Mathf.Rad2Deg);
        Move();
     /*   if (animator != null)
        {
            if (MoveVector.x != 0 && MoveVector.y != 0)
            {
                animator.Play("Walk");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        */
       
    }
    public void Move()
    {
        rb.AddForce(MoveVector * moveSpeed);
    }

    public Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = joystick.Horizontal();
        dir.y = joystick.Vertical();
        dir.z = 0;

        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }

        return dir;
    }
}
