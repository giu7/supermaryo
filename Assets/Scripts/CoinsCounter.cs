using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour {

    private TextMeshProUGUI coinsCounterText;
    private string baseString = "Coins: ";
    
    private void Awake() {
        coinsCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        coinsCounterText.text = baseString + GameManager.Instance.coins.ToString();
    }
}
