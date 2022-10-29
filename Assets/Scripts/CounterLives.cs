using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterLives : MonoBehaviour {

    private TextMeshProUGUI counterLivesText;
    private string baseString = "<sprite=0> x ";
    
    private void Awake() {
        counterLivesText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        counterLivesText.text = baseString + GameManager.Instance.lives.ToString();
    }
}
