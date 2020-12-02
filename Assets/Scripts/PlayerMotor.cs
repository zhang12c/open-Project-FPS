using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;

    private Vector3 rotation = Vector3.zero;

    private Vector3 cameraRotaion = Vector3.zero;

    [SerializeField]
    public Camera cam;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }
    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }
    public void CameraRotate(Vector3 _cameraRotation)
    {
        cameraRotaion = _cameraRotation;
    }
    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
        PerformCameraRotation();
    }

    private void PerformCameraRotation()
    {
        if (cam != null)
        {
            cam.transform.Rotate(cameraRotaion); 
        }
    }

    private void PerformRotation()
    {
        if (rotation != Vector3.zero)
        {
            
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation) );
        }
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }


    
}
