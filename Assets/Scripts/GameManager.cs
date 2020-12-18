using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : MonoBehaviour
    {
        private const string PLAYER_PREFIX = "Player";
        private static Dictionary<string, Player> players = new Dictionary<string, Player>();

        public static void RegisterPlayer(string _netID,Player _player)
        {
            string playerID = PLAYER_PREFIX + _netID;
            players.Add(playerID,_player);
            _player.transform.name = playerID;
        }

        public static void  UnRegisterPlayer(string _playerID)
        {
            players.Remove(_playerID);
        }
    }
}