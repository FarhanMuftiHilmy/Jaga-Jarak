using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Panel; //panel to restart and go to menu 
    public Text timerDisplay;
    private bool kalah;
    public float timer;

    private void Update()
    {
        if(kalah == false)
        {
            timerDisplay.text = timer.ToString("F0"); //durasi waktu dalam bentuk integer
        
            if(timer <= 0) // lanjut ke level selanjutnya
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            } else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    public void GameOver()
    {
        Panel.SetActive(true);
        kalah = true;
    }
    public void GoToGameScene()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
