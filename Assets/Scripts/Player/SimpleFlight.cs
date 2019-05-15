using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlight : MonoBehaviour
{
    private float vel = 0.0f;
    [SerializeField] private float thrust = 20.0f;
    [SerializeField] private float maxVel = 200.0f;
    private Transform t;
    public GameObject ground;

    void Awake()
    {
        t = gameObject.transform;
    }

    void Update()
    {
        MovePlayer();
        ContainPlayerToArea();
    }

    void MovePlayer()
    {
        if(Input.GetButton("Thrust") && vel < maxVel)
        {
            vel += thrust;
        }
        else if(Input.GetButton("De-Throttle") && vel > (0.05f * maxVel))
        {
            vel *= 0.97f;
        }
        
        if(vel <= maxVel)
        {
            t.position += -(t.forward * Time.deltaTime * vel);
            vel -= -(transform.forward.y * Time.deltaTime * 30.0f);
        }
        else
        {
            vel = maxVel;
        }
        
        transform.Rotate( -Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal"));
    }

    void ContainPlayerToArea()
    {
        if(ground.transform.position.y + 0.5f > t.position.y)
        {
            t.position = new Vector3 (t.position.x, ground.transform.position.y + 0.5f, t.position.z);
        }

        if(ground.transform.position.x + 1000.0f < t.position.x)
        {
            t.position = new Vector3 (ground.transform.position.x - 1000.0f,t.position.y,t.position.z);
        }
        else if(ground.transform.position.x - 1000.0f > t.position.x)
        {
            t.position = new Vector3 (ground.transform.position.x + 1000.0f,t.position.y,t.position.z);
        }

        if(ground.transform.position.z + 1000.0f < t.position.z)
        {
            t.position = new Vector3 (t.position.x,t.position.y,ground.transform.position.z - 1000.0f);
        }
        else if(ground.transform.position.z - 1000.0f > t.position.z)
        {
            t.position = new Vector3 (t.position.x,t.position.y,ground.transform.position.z + 1000.0f);
        }
    }
}
