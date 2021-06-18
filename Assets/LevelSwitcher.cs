using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSwitcher : MonoBehaviour
{
    public static LevelSwitcher instance;
    public Level[] levels = new Level[100];
    public Level currentLevel;
    [SerializeField] private Ball player;    
    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        instance = this;
        int id = 0;
        foreach (var level in levels)
        {
            level.id = id++;
            HideLevel(level);
        }
        Load(levels[0], false);
    }

    public void LoadNextLevel()
    {
        try
        {
            var nextLevel = levels[currentLevel.id + 1];
            if (nextLevel)
            {
                Load(nextLevel);
            }
            else
            {
                Load(levels[0]);
            }
        }
        catch (IndexOutOfRangeException e)
        {
            Load(levels[0]);
        }        
    }

    public void Load(Level level, bool MovePlayerToStartPoint = true)
    {
        HideCurrentLevel();
        level.transform.position = Vector3.zero;
        level.gameObject.SetActive(true);
        currentLevel = level;
        if (MovePlayerToStartPoint)
            player.MoveToStart();
    }

    private void HideCurrentLevel()
    {
        HideLevel(currentLevel);   
    }

    private void HideLevel(Level level)
    {
        if (level)
            level.gameObject.SetActive(false);
    }

    public void StartFadeIn()
    {
        StartCoroutine(nameof(FadeIn));
    }

    public void StartFadeOut()
    {
        StartCoroutine(nameof(FadeOut));
    }

    private IEnumerator FadeIn()
    {
        fadeImage.enabled = true;
        for (int i = 0; i < 100; i++)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, (float)i / 100);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator FadeOut()
    {        
        for (int i = 100; i > 0; i--)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, (float)i / 100);
            yield return new WaitForSeconds(0.01f);
        }
        fadeImage.enabled = false;
    }

}
