using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; set;}
    int keysToFind; 
    int foundKeys;

    [SerializeField] TextMeshProUGUI foundKeysScore;
    private int numberOfKeysToFind;
    private void Awake() {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start() {
        keysToFind = GameObject.FindGameObjectsWithTag("Key").Length;
        foundKeys = 0;
    }

    public void foundKey() {
        foundKeys++;
        UpdateFoundKeysScore();
    }


    public void UpdateFoundKeysScore() {
        
        foundKeysScore.text = $"{foundKeys}/{keysToFind}";
    }
}
