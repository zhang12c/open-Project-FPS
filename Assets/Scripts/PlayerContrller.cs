using System;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerContrller : MonoBehaviour
{
    [SerializeField] 
    private float moveSpeed = 5f;

    [SerializeField] private float rotationSpeed = 3f;

    [SerializeField] private float jumpForce = 1000f;

    [Header("ConfigurableJoint Settings")] 
    [SerializeField] private JointDriveMode jointMode = JointDriveMode.None;
    [SerializeField] private float maximumForce = 40f;
    [SerializeField] private float jointSprint = 20f;
    
    private PlayerMotor motor;
    private void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    private void Update()
    {
    //获取x , z 的值
    float _xMov = Input.GetAxis("Horizontal");
    float _zMov = Input.GetAxis("Vertical");
    
    // 向x,z 的移动向量
    Vector3 _movHorizontal = transform.right * _xMov;
    Vector3 _moveVertical = transform.forward * _zMov;
    
    // 将x,z 移动向量组成一个面
    Vector3 _velocity = (_moveVertical + _movHorizontal).normalized * moveSpeed;
    
    // 调用Move方法
    motor.Move(_velocity);
    
    // 获取鼠标x 的值,则物体是绕着Y轴旋转，改变的是Y值
    float _yRot = Input.GetAxis("Mouse X");
    
    // 水平旋转的量
    Vector3 _rotation = new  Vector3(0f,_yRot,0f) * rotationSpeed;
    
    // 调用Rotation方法
    motor.Rotate(_rotation);
    
    // 获取鼠标y 的值,则物体是绕着Y轴旋转，改变的是x值
    float _xRot = Input.GetAxis("Mouse Y");
    
    // 水平旋转的量
    Vector3 _cameraRotation = new  Vector3(-_xRot,0f,0f) * rotationSpeed;
    
    // 调用Rotation方法
    motor.CameraRotate(_cameraRotation);

    Vector3 _jumpDir = Vector3.zero;

    if (Input.GetButton("Jump"))
    {
        _jumpDir = Vector3.up * jumpForce;
    }
    motor.Jump(_jumpDir);
    }
}
