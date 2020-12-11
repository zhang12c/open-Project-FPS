using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] private Camera cam;
    
    [SerializeField] private LayerMask _mask;

    public PlayerWeapon _playerWeapon;
    private void Awake()
    {
        if (cam == null)
        {
            Debug.LogError("Camera is no found");
            this.enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // 存放被击中的目标
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out _hit,_playerWeapon.range,_mask))
        {
            Debug.Log(_hit.collider.name);
        }
    }
}
