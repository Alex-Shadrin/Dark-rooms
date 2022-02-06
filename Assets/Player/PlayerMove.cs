using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    public float speed = 3f;
    private Camera _camera;
    int isWalkingHash;
    int isRunningHash;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _camera = Camera.main;
        //Cursor.lockState = CursorLockMode.Locked;
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    void Update()
    {
        //bool isRunning = animator.GetBool(isRunningHash);
        //bool isWalking = animator.GetBool(isWalkingHash);
        //bool forwardPressed = Input.GetKey("w");
        //bool runPressed = Input.GetKey("left shift");

        //if(!isWalking && forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, true);
        //}

        //if (isWalking && !forwardPressed)
        //{
        //    animator.SetBool(isWalkingHash, false);
        //}

        //if (!isRunning && (forwardPressed && runPressed))
        //{
        //    animator.SetBool(isRunningHash, true);
        //}

        //if (isRunning && (!forwardPressed || !runPressed))
        //{
        //    animator.SetBool(isRunningHash, false);
        //}
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 derectionVector = new Vector3(h, 0, v);
        Vector3 rotationVector = new Vector3(v, 0, -h);
        if (derectionVector.magnitude > Mathf.Abs(0.05f))

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(derectionVector), Time.deltaTime * rotationSpeed);
        animator.SetFloat("speed", Vector3.ClampMagnitude(derectionVector, 2).magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //animator.SetFloat("speed_run", Vector3.ClampMagnitude(derectionVector, 2).magnitude);
            speed = 5f;
        }
        else
        {
            speed = 3f;
        }
        rigidbody.velocity = Vector3.ClampMagnitude(derectionVector, 1) * speed;
    }

}
