using System.Collections.Generic;
using UnityEngine;

namespace UI.Players
{
    public class PlayersManager : MonoBehaviour
    {
        private static Dictionary<string, int> _players = new Dictionary<string, int>()
        {
            {"Player", 0}
        };

        public static void AddPlayers(string nickName)
        {
            _players.Add(nickName,_players.Count);
            Debug.Log(_players[nickName]);
        }

        public static void RemovePlayers(string nickName)
        {
            Debug.Log(_players[nickName]);
            _players.Remove(nickName);
            
        }
    }
}