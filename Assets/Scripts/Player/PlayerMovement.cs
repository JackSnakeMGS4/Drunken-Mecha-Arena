using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    [SerializeField] private float fowardMoveSpeed = 50.0f;
    [SerializeField] private float turnSpeed = 100.0f;
    [SerializeField] private float backwardMoveSpeed = 35.0f;
    [SerializeField] private float strafingRightMoveSpeed = 50.0f;
    [SerializeField] private float strafingLeftMoveSpeed = 50.0f;


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

        //NOTE 1: Refer to NOTE 2
        //animator = GetComponent<Animator>();

        //TODO: Make the following line toggable in game
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //TODO: Implement strafing left and right 
        var horizontalRot = Input.GetAxis("Mouse X");
        var horizontalStrafe = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontalRot, 0, vertical);

        //animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontalRot * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = vertical > 0 ? fowardMoveSpeed : backwardMoveSpeed;

            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
        if(horizontalStrafe != 0)
        {
            float strafeSpeedToUse = horizontalStrafe > 0 ? strafingRightMoveSpeed : strafingLeftMoveSpeed;

            characterController.SimpleMove(transform.right * strafeSpeedToUse * horizontalStrafe);
        }
    }
}
