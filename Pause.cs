using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;
using System.IO;

/*
Timotej Medved 
4.4.2020
*/

public class Pause : MonoBehaviour
{
     //  Cursor.visible = false;
    
    [SerializeField] private GameObject pauseMenuUI;


    bool isPaused = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
        }

        if(isPaused){
            ActivateMenu();
        }else{
            DeactivateMenu();
        }

    }

    void ActivateMenu(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
             isPaused = true;
             Cursor.visible = true;
    }

    void DeactivateMenu(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
             isPaused = false;
             Cursor.visible = false;
    }

    
    public void resume(){
        DeactivateMenu();
    }

    public void goToMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void exit(){
        Application.Quit();
    }

    
}
