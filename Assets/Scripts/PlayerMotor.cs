using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;

    private Vector3 rotation = Vector3.zero;

    private float cameraRotaionX = 0f;

    private float currentCameraRotationX = 0f;

    Vector3 jumpDir = Vector3.zero;
    [SerializeField] private float cameraRotationLimit = 85f;
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
    public void CameraRotate(float _cameraRotation)
    {
        cameraRotaionX = _cameraRotation;
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
            //cam.transform.Rotate(cameraRotaionX); 
            currentCameraRotationX -= cameraRotaionX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX,0f,0f);
        }
    }

    private void PerformRotation()
    {
        if (rotation != Vector3.zero)
        {
            
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation).normalized );
        }
    }

    private void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
        rb.AddForce(jumpDir * Time.deltaTime );
    }

    
    public void Jump(Vector3 _jumpDir)
    {
        jumpDir = _jumpDir;
    }
}
