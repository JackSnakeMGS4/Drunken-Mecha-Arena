using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBetweenMechaAndPlane : MonoBehaviour
{
    [SerializeField] private GameObject mecha;
    [SerializeField] private GameObject plane;
    [SerializeField] private GameObject planeCam;
    [SerializeField] private GameObject mechaCam;

    [HideInInspector] public bool isPlaneModeActive = false;

    void Start()
    {
        if(plane.activeSelf)
        {
            isPlaneModeActive = true;
            mecha.SetActive(!isPlaneModeActive);
        }
        else
        {
            isPlaneModeActive = false;
            mecha.SetActive(!isPlaneModeActive);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //BUG: Single press does nothing but a double tapping the button executes the code
        if(Input.GetButtonDown("Transform"))
        {
            if(isPlaneModeActive)
            {
                isPlaneModeActive = !isPlaneModeActive;
            }
            else
            {
                isPlaneModeActive = !isPlaneModeActive;
            }
            SetPos();
            plane.SetActive(isPlaneModeActive);
            mecha.SetActive(!isPlaneModeActive);
        }
    }

    private void SetPos()
    {
        if(isPlaneModeActive)
        {
            plane.transform.position = gameObject.transform.position;
            plane.transform.rotation = gameObject.transform.rotation;
            planeCam.SetActive(true);
            mechaCam.SetActive(false);
        }
        else
        {
            mecha.transform.position = gameObject.transform.position;
            mecha.transform.rotation = gameObject.transform.rotation;
            planeCam.SetActive(false);
            mechaCam.SetActive(true);
        }
    }
}
