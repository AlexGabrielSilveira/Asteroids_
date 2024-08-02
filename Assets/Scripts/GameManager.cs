using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance {get; private set;}
    public float GameWidth = 16.38f;
    public float GameHeight = 9;

    
    public bool isGameOver = false;
    public int Score = 0;
    public int PlayerHealth = 100;

    private void Awake()
    {  
        if(Instance != null && Instance != this) {
            Destroy(Instance);
        }else {
            Instance = this;
        }
        
    }
    public void GameOver() {
        Invoke("RestartGame", 1.5f);
    }
    void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}