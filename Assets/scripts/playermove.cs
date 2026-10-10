using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    private Vector3 moveInput;
    private Camera cam;

    public float speed = 5f;
    public float verticalspeed = 5f;
    public float rotationSpeed = 10f;

    public Animator animator;

    public CharacterController controller;

    
    // Start is called before the first frame update
    void Start()
    {

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.z = Input.GetAxis("Vertical");

        float verticalMovement = Input.GetAxis("Jump");

        animator.SetBool("IsMoving", moveInput.magnitude != 0);

        moveInput = Vector3.ClampMagnitude(moveInput, 1f);

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 horizontalMove = (moveInput.z * camForward + moveInput.x * camRight) * speed;

        Vector3 verticalMove = verticalMovement * Vector3.up * verticalspeed;

        Vector3 finalMove = horizontalMove + verticalMove;


        float targetYaw = horizontalMove.sqrMagnitude > 0.01f ? Quaternion.LookRotation(horizontalMove).eulerAngles.y : transform.rotation.eulerAngles.y;

        float targetPitch = -verticalMovement * 15f;

        Quaternion targetRotation = Quaternion.Euler(targetPitch, targetYaw, 0f);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        controller?.Move(finalMove * Time.deltaTime);
    }


}
