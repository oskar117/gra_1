using UnityEngine;
using System.Collections;

public class legsDir : MonoBehaviour
{
    PlayerMovement pm;
    private Animator anim;
    public float rotation;

    void Start()
    {
        anim = GetComponent<Animator>() as Animator;
        pm = gameObject.GetComponentInParent<PlayerMovement>();
    }
	void FixedUpdate ()
    {
        rotation = pm.heading;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation * -Mathf.Rad2Deg);

        if (anim != null)
        {
            if (pm.MoveVector.x != 0 && pm.MoveVector.y != 0)
            {
                anim.Play("Walk");
            }
            else
            {
                anim.Play("Idle");
            }
        }
        
    }
}
