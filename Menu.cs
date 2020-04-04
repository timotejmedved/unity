using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //dodamo knjižnico
using System;
using UnityEngine.UI;
using System.IO;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PLay(){
    	
        SceneManager.LoadScene("SampleScene");
    }

    public void Exit(){
    	
        Application.Quit();
    }

}
