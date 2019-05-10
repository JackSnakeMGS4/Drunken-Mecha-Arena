using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlight : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float vel = 1000.0f;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // change this to transform movement instead of rigibody for prototype's sake
        // rigidbody bullshit can wait until your in the production cycle
        float mH = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (0.0f,0.0f,mH);
        rb.AddForce(movement * vel);
    }
}
