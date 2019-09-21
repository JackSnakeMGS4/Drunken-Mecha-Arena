using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField] private float moveSpeed = 1250;
    [SerializeField] private float turnSpeed = 5;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        //NOTE 1: Refer to NOTE 2
        //animator = GetComponent<Animator>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        characterController.SimpleMove(movement * Time.deltaTime * moveSpeed);

        //NOTE 2: uncomment animator once you get your crude idle and running animations done in Blender
        //animator.SetFloat("Speed", movement.magnitude);

        if(movement.magnitude > 0)
        {
            Quaternion newDirection = Quaternion.LookRotation(movement);

            transform.rotation = Quaternion.Slerp(transform.rotation, newDirection, Time.deltaTime * turnSpeed);
        }
    }
}
