using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterWorld : MonoBehaviour {

    private TextMeshProUGUI counterWorldText;
    private string baseString = "<sprite=0> x ";
    
    private void Awake() {
        counterWorldText = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        counterWorldText.text = baseString + GameManager.Instance.level;
    }
}
