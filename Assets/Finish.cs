using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Level level;
    private bool isActive = true;
    private LevelSwitcher levelSwitcher;

    private void Start()
    {
        levelSwitcher = FindObjectOfType<LevelSwitcher>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            FinishLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() && isActive)
        {
            isActive = false;
            FinishLevel();            
        }
    }

    private void FinishLevel()
    {
        Invoke(nameof(LoadNextLevel), 2);
        levelSwitcher.StartFadeIn();
    }

    public void LoadNextLevel()
    {
        levelSwitcher.LoadNextLevel();
        levelSwitcher.StartFadeOut();
        isActive = true;
    }
}
