using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject m_Target;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(m_Target.transform.position.x,
                                  m_Target.transform.position.y,
                                  transform.position.z);

    }
}
