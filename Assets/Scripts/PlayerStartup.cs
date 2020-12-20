using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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

    private void Update()
    {
        ShowPlayer();
    }

    private void ShowPlayer()
    {
        Dictionary<string, Player> _players = GameManager.GetPlayers();
        int index = 1;
        foreach (var VARIABLE in _players)
        {
            string path = string.Format("BG/Player" + index);
            canvas.transform.Find(path).gameObject.SetActive(true);
            Text _text = canvas.transform.Find(path).GetComponent<Text>();
            _text.text = VARIABLE.Key;
            index += 1;
        }
    }
}
