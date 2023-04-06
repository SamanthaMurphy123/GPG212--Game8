using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image lifetimeBar;

    public static GameUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        scoreText.text = string.Format("SCORE\n{0}", GameManager.instance.score.ToString());
    }

    public void UpdateLifetimeBar()
    {
        lifetimeBar.fillAmount = GameManager.instance.lifeTime;
    }
}
