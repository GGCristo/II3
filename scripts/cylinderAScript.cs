using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cylinderAScript : MonoBehaviour
{
    public delegate void incrementForceDelegate();
    public static event incrementForceDelegate incrementForce;
    public delegate void proximityWithPlayerDelegate();
    public static event proximityWithPlayerDelegate proximityWithPlayer;
    private float distance;
    private GameObject player;
    Rigidbody m_Rigidbody;
    public Text message;

    void Start()
    {
        distance = 10.0f;
        player = GameObject.FindWithTag("Player");
        characterController.collisionA += OnCollision;
        cylinderBScript.sendMessage += OnMessage;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {}

    void FixedUpdate() {
        if(Vector3.Distance(transform.position, player.transform.position) < distance) {
            proximityWithPlayer();
        }
    }

    void OnCollision() {
        message.text = "";
        incrementForce();
    }

    void OnMessage() {
        message.text = "Collision text from A";
    }
}
