using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlight : MonoBehaviour
{
    [SerializeField] private float vel = 0.0f;
    [SerializeField] private float thrust = 20.0f;
    private Transform t;

    void Awake()
    {
        t = gameObject.transform;
    }

    void Update()
    {
        AccelarateOrDeccelerate();
    }

    void AccelarateOrDeccelerate()
    {
        if(Input.GetButton("Thrust"))
        {
            vel += thrust;
        }
        else if(Input.GetButton("De-Throttle"))
        {
            vel *= 0.97f;
        }
        
        t.position -= t.forward * Time.deltaTime * vel;
    }
}
