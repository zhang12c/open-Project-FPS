using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerStartup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] compentDisable;

    private Camera sceneCamera;

    /// <summary>
    /// 游戏角色的ID
    /// </summary>
    private string _ID;

    [SerializeField] private string remoteLayer = "RemotePlayer";


    private void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssignRemote();
        }
        else
        {
            sceneCamera = Camera.main;
            if (sceneCamera != null)
            {
                sceneCamera.gameObject.SetActive(false);
            }
        }
        RegisterPlayer();
    }

    private void RegisterPlayer()
    {
        // ID 如 ： Player1
        _ID = "Player" + gameObject.GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }

    private void AssignRemote()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayer);
    }

    void DisableComponents()
    {
        for (int i = 0; i < compentDisable.Length; i++)
        {
            compentDisable[i].enabled = false;
        }
    }
    

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
