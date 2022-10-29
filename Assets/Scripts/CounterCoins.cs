using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterCoins : MonoBehaviour {

    private TextMeshProUGUI counterCoinsText;
    private string baseString = "<sprite=0> x ";
    
    private void Awake() {
        counterCoinsText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        counterCoinsText.text = baseString + GameManager.Instance.coins.ToString();
    }
}
