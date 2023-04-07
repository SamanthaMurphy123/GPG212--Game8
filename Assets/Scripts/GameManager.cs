using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hitBlockScore = 10;
    public float lifeTime = 1.0f;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;
    public float startTime = 3.0f;


    public static GameManager instance;

   // public VelocityTracker leftSwordTracker;
  //  public VelocityTracker rightSwordTracker;

  //  public float swordHitVelocityThreshold = 0.5f;
    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score += hitBlockScore;
        GameUI.instance.UpdateScoreText();
    }

    public void MissBlock()
    {
        lifeTime -= missBlockLife;
    }

    public void HitWrongBlock()
    {
        lifeTime -= wrongBlockLife;
    }

    private void Update()
    {
        lifeTime = Mathf.MoveTowards(lifeTime, 1.0f, lifeRegenRate * Time.deltaTime);

        if (lifeTime <= 0.0f)
        {
            LoseGame();
        }

        GameUI.instance.UpdateLifetimeBar();

        if (GameObject.FindGameObjectsWithTag("Block").Length == 0)
        {
            SceneManager.LoadScene("Win Scene");
        }
    }

    public void WinGame()
    {
        SceneManager.LoadScene("Win Scene");
    }

    public void LoseGame()
    {
        SceneManager.LoadScene("LoseScene");

    }
}
