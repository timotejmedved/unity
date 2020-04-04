using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //dodamo knjižnico
using System;
using UnityEngine.UI;
using System.IO;
//timotej medved 3.4.2020
public class tocke : MonoBehaviour
{
    private class Data{
        public int score;
    }
    
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setscore();
    }


    void setscore(){

        string json = File.ReadAllText(Application.dataPath + "/Data/izbira.json"); //naloži podatke iz datoteke .json
        Data playerDataLoaded = JsonUtility.FromJson<Data>(json); //pošlje vse podatke v razred PlayerData

        string kov = playerDataLoaded.score.ToString();

        score.text = "SCORE:" + kov;
    }
}
