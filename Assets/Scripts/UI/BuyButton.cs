using TMPro;
using UnityEngine;

namespace UI
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _priceText;
        [SerializeField] private TextMeshProUGUI _productNameText;
        [SerializeField] private TextMeshProUGUI _numPropositionText;

        public void DrawNumberOf(string itemNumber, string price, string product)
        {
            _numPropositionText.text = itemNumber;
            _priceText.text = price + "$";
            _productNameText.text = product + ": ";
            
        }
    }
}