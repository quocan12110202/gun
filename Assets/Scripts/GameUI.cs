using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI HighScore;
   
    void Update()
    {
        Score.SetText(GameManager.Instance.GetScore().ToString());
        HighScore.SetText(GameManager.Instance.GetScore().ToString());
        
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }
}
