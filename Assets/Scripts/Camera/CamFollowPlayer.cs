using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private SimpleFlight playerFlightControl;

    void Awake()
    {
        playerFlightControl = player.GetComponent<SimpleFlight>();
    }
    void LateUpdate()
    {
         /* set cam to player pos and move it back by 3 meters on the the forward axis 
         and move it up 5 meters in the global up axis */

        Vector3 camGoTo = player.transform.position - player.transform.forward * -10.0f + Vector3.up * 2.0f;
        
        //this is one of many ways to implement a spring function
        float bias = 0.96f;
        Camera.main.transform.position = Camera.main.transform.position * bias + camGoTo * (1.0f - bias);

        Camera.main.transform.LookAt(player.transform.position - player.transform.forward * 50.0f);
    }
}
