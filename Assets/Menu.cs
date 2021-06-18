using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject inGameElements;
    private bool joystickControlInverted;

    public bool JoystickControlInverted {
        get
        {
            return joystickControlInverted; 
        }
        set
        {
            joystickControlInverted = value;
        } }

    void Start()
    {
        OpenMenu(); JoystickControlInverted = false;
    }

    public void PlayButton()
    {
        menu.SetActive(false);
        inGameElements.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenMenu()
    {
        menu.SetActive(true);
        inGameElements.SetActive(false);
        Time.timeScale = 0;
    }

}
