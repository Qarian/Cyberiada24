using System;
using System.Collections;
using System.Collections.Generic;
using Presentation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    public void Run(NavControler controller)
    {
        StartCoroutine(controller.Pickup());
    }

    private void Start()
    {
        exitButton?.onClick.AddListener(Exit);
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
