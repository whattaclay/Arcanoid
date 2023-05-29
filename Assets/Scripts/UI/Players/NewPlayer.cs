using TMPro;
using UnityEngine;

namespace UI.Players
{
    public class NewPlayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI playerNickname;
        private char[] _letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
        private string _newNickName = "";

        public void RandomNickName()
        {
            int _nickLenght = Random.Range(5, 10);
            while (_newNickName.Length < _nickLenght)
            {
                _newNickName += _letters[Random.Range(0, _letters.Length)];
            }
            playerNickname.text = _newNickName;
            PlayersManager.AddPlayers(_newNickName);
        }

        public void RemovePlayer()
        {
            PlayersManager.RemovePlayers(_newNickName); 
            Destroy(gameObject);
        }
    }
}