using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hitBlockScore = 10;
    public float lifeTime = 1.0f;
    public float missBlockLife = 0.1f;
    public float wrongBlockLife = 0.08f;
    public float lifeRegenRate = 0.1f;

    public static GameManager instance;

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
        GameUI.instance.UpdateLifetimeBar();
    }
}
