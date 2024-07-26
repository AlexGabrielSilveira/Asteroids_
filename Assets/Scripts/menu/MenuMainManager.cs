using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private GameObject MenuStart;
    [SerializeField] private GameObject MenuOptions;
    public void Play() {
        SceneManager.LoadScene(2);
    }
    public void OpenSettingsMenu() {
        MenuStart.SetActive(false);
        MenuOptions.SetActive(true);

    }
    public void CloseSettingsMenu() {
    MenuStart.SetActive(true);
        MenuOptions.SetActive(false);
    }
    public void Quit() {
        Debug.Log("Sair do jogo!");
        Application.Quit();
    }
}
