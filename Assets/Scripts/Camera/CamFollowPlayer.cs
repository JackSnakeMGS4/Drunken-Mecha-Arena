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
        Camera.main.transform.position = fpsCam.position;
    }
}
