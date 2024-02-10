using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    void Awake()
    {
       textMesh = GetComponent<TextMeshProUGUI>();  
    }

    void Update()
    {
        
    }

    public void UpdateText(string newText) {
        textMesh.text = newText;
    }
}
