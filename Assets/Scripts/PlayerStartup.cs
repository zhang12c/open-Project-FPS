using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
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

    [SerializeField] private Canvas canvas;

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
        
    }

    public override void OnStartClient()
    {
        base.OnStartClient();
        _ID = gameObject.GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();
        GameManager.RegisterPlayer(_ID,_player);
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
        GameManager.UnRegisterPlayer(transform.name);
    }

    private void ShowPlayer()
    {
        
    }
}
