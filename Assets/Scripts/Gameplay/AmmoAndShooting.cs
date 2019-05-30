using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAndShooting : MonoBehaviour
{
    [SerializeField] private GameObject ammo1;
    [SerializeField] private GameObject ammo2;

    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
