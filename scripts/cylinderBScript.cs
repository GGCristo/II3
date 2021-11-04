using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderBScript : MonoBehaviour
{
    public delegate void sendMessageDelegate();
    public static event sendMessageDelegate sendMessage;
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        characterController.collisionB += OnCollision;
        cylinderAScript.incrementForce += OnIncrementForce;
        cylinderAScript.proximityWithPlayer += changeColor;
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void OnCollision() {
        sendMessage();
    }

    void OnIncrementForce() {
        m_Rigidbody.mass += 1.0f;
        print("From B: My mass now is: " + m_Rigidbody.mass);
    }

    void changeColor() {
        gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }
}
