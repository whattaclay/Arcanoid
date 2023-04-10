using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SelectItemToBuy : MonoBehaviour
    {
        [SerializeField] private BuyButton _buyButtonPrefab;
        [SerializeField] private RectTransform _content;
        

        private void Awake()
        {
            int rNumber = Random.Range(5, 20);
            int[] prices = { 100, 150, 200, 250, 300, 350, 400, 450, 500 };
            List<string> products = new List<string>()
            {
                "Helmet", "ChestPlate", "Leggings", "Boots", "Axe", "Bow", "Crossbow", "Sword",
                "Tridents", "Shield", "Firework", "Big Fish", "Chair", "Blade", "Awesome hat",
                "Scissors", "Hammer", "Ball skin", "Extra Live", "Nothing"
            };
            for (int i = 0; i < rNumber; i++)
            {
                int randomItem = Random.Range(0, products.Count);
                int randomPrice = Random.Range(0, prices.Length-1);
                var buttonInstance = Instantiate(_buyButtonPrefab, _content);
                buttonInstance.DrawNumberOf((i+1).ToString(),
                    prices[randomPrice].ToString(),
                    products[randomItem]);
                products.RemoveAt(randomItem);
            }
        }
    }
}