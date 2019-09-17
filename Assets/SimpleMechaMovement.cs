using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMechaMovement : MonoBehaviour
{
    private float vel = 0.0f;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float maxSpeed = 50.0f;
    private Transform t;
    public GameObject ground;

    void Awake()
    {
        t = gameObject.transform;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        MovePlayer();
        ContainPlayerToArea();
    }

    void MovePlayer()
    {
        t.Translate(Vector3.forward * speed * -Input.GetAxis("Vertical") * Time.deltaTime);
        t.Translate(Vector3.right * speed * -Input.GetAxis("Horizontal") * Time.deltaTime);
        t.Translate(Vector3.up * speed * Input.GetAxis("Ascend/Descend") * Time.deltaTime);

        transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0.0f);

        if (Input.GetKeyDown(KeyCode.U))
        {
            Destroy(gameObject);
        }
    }

    void ContainPlayerToArea()
    {
        if (ground.transform.position.y + 0.5f > t.position.y)
        {
            t.position = new Vector3(t.position.x, ground.transform.position.y + 0.5f, t.position.z);
        }

        if (ground.transform.position.x + 1000.0f < t.position.x)
        {
            t.position = new Vector3(ground.transform.position.x - 1000.0f, t.position.y, t.position.z);
        }
        else if (ground.transform.position.x - 1000.0f > t.position.x)
        {
            t.position = new Vector3(ground.transform.position.x + 1000.0f, t.position.y, t.position.z);
        }

        if (ground.transform.position.z + 1000.0f < t.position.z)
        {
            t.position = new Vector3(t.position.x, t.position.y, ground.transform.position.z - 1000.0f);
        }
        else if (ground.transform.position.z - 1000.0f > t.position.z)
        {
            t.position = new Vector3(t.position.x, t.position.y, ground.transform.position.z + 1000.0f);
        }
    }
}
