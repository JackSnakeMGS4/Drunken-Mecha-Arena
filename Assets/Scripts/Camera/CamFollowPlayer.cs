using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform fpsCam;

    void Awake()
    {
        Camera.main.transform.position = fpsCam.position;
    }
    void Update()
    {
        Camera.main.transform.position = fpsCam.position + new Vector3(0,1.0f,10.0f);
        Camera.main.transform.LookAt(fpsCam.position + new Vector3(0,0,-3.0f),Vector3.up);
    }
}
