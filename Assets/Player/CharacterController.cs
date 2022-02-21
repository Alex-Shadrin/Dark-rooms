using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class CharacterController : MonoBehaviour
{
    private Animator animator;
    private new Rigidbody rigidbody;
    private CharacterController chController;
    public float rotationSpeed = 10f;
    public float speed = 3f;
    private Camera _camera;
    int isWalkingHash;
    int isRunningHash;
    public float lookspeed = 1f;
    private Vector3 moveVector;


    private void Start()
    {
        //chController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
        //Cursor.lockState = CursorLockMode.Locked;
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        CharacterMove();
    }
    private void CharacterMove()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 derectionVector = new Vector3(h, 0, v);
        Vector3 rotationVector = new Vector3(v, 0, -h);
        if (derectionVector.magnitude > Mathf.Abs(0.05f))

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(derectionVector), Time.deltaTime * rotationSpeed);
        animator.SetFloat("speed", Vector3.ClampMagnitude(derectionVector, 1).magnitude);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5f;
            animator.SetFloat("speed", Vector3.ClampMagnitude(derectionVector, 2).magnitude);
            rigidbody.velocity = Vector3.ClampMagnitude(derectionVector, 2) * speed;
        }
        else
        {
            speed = 3f;
        }
        rigidbody.velocity = Vector3.ClampMagnitude(derectionVector, 1) * speed;

        //moveVector = Vector3.zero;
        //moveVector.x = Input.GetAxis("Horizontal") * speed;
        //moveVector.z = Input.GetAxis("Vertical") * speed;

        //chController.Move(moveVector * Time.deltaTime);

        //if (moveVector.x! = 0 || moveVector.z! = 0) animator.SetBool("isWalking", true);

        //заставляет персонажа следить за курсором мышки
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookspeed * Time.deltaTime);
        }
    }
}