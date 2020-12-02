using UnityEngine;
using UnityEngine.Networking;

public class PlayerStartup : NetworkBehaviour
{
    [SerializeField]
    private Behaviour[] compentDisable;

    private Camera sceneCamera;
    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < compentDisable.Length; i++)
            {
                compentDisable[i].enabled = false;
            }
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

    private void OnDisable()
    {
        if (sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }
}
