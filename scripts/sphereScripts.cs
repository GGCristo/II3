using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereScripts : MonoBehaviour
{
    private GameObject player;
    public float m_Speed = 10.0f;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody>();
        cylinderAScript.proximityWithPlayer += orientateToPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, player.transform.position - transform.position,
         Color.green);
    }

    void orientateToPlayer() {
        transform.LookAt(player.transform);
        m_Rigidbody.velocity = transform.forward * m_Speed;
    }
}
