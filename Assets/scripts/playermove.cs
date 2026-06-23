using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    private Vector3 moveInput;
    private Camera cam;

    public float speed = 5f;
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

        animator.SetBool("IsMoving", moveInput.magnitude != 0);

        moveInput = Vector3.ClampMagnitude(moveInput, 1f);

        Vector3 camForward = cam.transform.forward;
        Vector3 camRight = cam.transform.right;
        camForward.y = 0f;
        camRight.y = 0f;

        Vector3 finalMove =  (moveInput.z * camForward + moveInput.x * camRight) * speed;


        if (finalMove.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(finalMove);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        controller.Move(finalMove * Time.deltaTime);
    }
}
