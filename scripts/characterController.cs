using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public delegate void collisionDelegate();
    public static event collisionDelegate collisionA;
    public static event collisionDelegate collisionB;
    public float speed = 5.0f;
    public int puntuation = 0;
    
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) 
        || Input.GetKey(KeyCode.D)) {
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_Input * Time.deltaTime * speed);
        }
    }

    void OnCollisionEnter(Collision collisionObj)
    {
        if (collisionObj.gameObject.tag == "A") {
            if (collisionA != null) {
                collisionA();
            }
        }
        if (collisionObj.gameObject.tag == "B") {
            if (collisionB != null) {
                collisionB();
            }
        }
    }
}
