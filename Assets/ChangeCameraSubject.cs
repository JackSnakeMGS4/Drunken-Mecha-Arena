using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraSubject : MonoBehaviour
{
    [SerializeField] private GameObject playerMecha;
    [SerializeField] private GameObject playerPlane;
    [SerializeField] private GameObject planeLookAt;
    [SerializeField] private GameObject mechaLookAt;
    private TransformBetweenMechaAndPlane planeMode;
    private TransformBetweenMechaAndPlane mechaMode;
    private Cinemachine.CinemachineVirtualCamera cam1;
    
    void Start()
    {
        planeMode = playerPlane.GetComponent<TransformBetweenMechaAndPlane>();
        mechaMode = playerMecha.GetComponent<TransformBetweenMechaAndPlane>();
        cam1 = gameObject.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    void Update()
    {
        if(planeMode.isPlaneModeActive)
        {
            cam1.Follow.SetPositionAndRotation(new Vector3(playerPlane.transform.position.x, playerPlane.transform.position.y, playerPlane.transform.position.z), 
                playerPlane.transform.rotation);
            cam1.LookAt.LookAt(planeLookAt.transform);
        }
        else
        {
            cam1.Follow.SetPositionAndRotation(new Vector3(playerMecha.transform.position.x, playerMecha.transform.position.y, playerMecha.transform.position.z),
                playerPlane.transform.rotation);
            cam1.LookAt.LookAt(mechaLookAt.transform);
        }
    }
}
