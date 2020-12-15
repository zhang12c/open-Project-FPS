using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    [SerializeField] private Camera cam;
    
    [SerializeField] private LayerMask _mask;

    public PlayerWeapon _playerWeapon;

    private const string PLAYER_TAG = "Player";
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
[Client]
    private void Shoot()
    {
        // 存放被击中的目标
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position,cam.transform.forward,out _hit,_playerWeapon.range,_mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
            Debug.Log(_hit.collider.name);
        }
    }

    [Command]
    void CmdPlayerShot(string _ID)
    {
        Debug.Log(_ID+"被攻击");
    }
}
