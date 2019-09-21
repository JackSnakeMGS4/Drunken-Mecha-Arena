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

        //animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if(vertical != 0)
        {
            float moveSpeedToUse = vertical > 0 ? fowardMoveSpeed : backwardMoveSpeed;

            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }
    }
}
