using UnityEngine;

namespace UI.Players
{
    public class NewPlayerButton : MonoBehaviour
    {
        [SerializeField] private NewPlayer playerPrefab;
        [SerializeField] private RectTransform content;

        public void InstancePlayer()
        {
            var newPlayer = Instantiate(playerPrefab, content);
            newPlayer.RandomNickName();
        }
    }
}