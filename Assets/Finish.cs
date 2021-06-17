using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Level level;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            FinishLevel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            FinishLevel();            
        }
    }

    private void FinishLevel()
    {
        Invoke(nameof(LoadNextLevel), 2);
        LevelSwitcher.instance.StartFadeIn();
    }

    public void LoadNextLevel()
    {
        LevelSwitcher.instance.LoadNextLevel();
        LevelSwitcher.instance.StartFadeOut();
    }
}
