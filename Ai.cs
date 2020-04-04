using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //dodamo knjižnico
using System;
using UnityEngine.UI;
using System.IO;

public class Ai : MonoBehaviour
{
    public Transform target;
    public Transform myTransform;
    public float speed = 5f;
    public AudioClip hit_hurt;
    public AudioClip death;
    public AudioSource audioSrc;
    public int health = 1;



     private class Data{
        public int score;
    }

      private class Data1{
       
        public int limit;
        public int limitOnStart;
    }

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        var temp = GameObject.FindGameObjectWithTag("IzvorZvoka");
        audioSrc = temp.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        myTransform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (health == 0)
        {
            Destroy(gameObject);
            audioSrc.PlayOneShot(death);
        }
    }

    void OnCollisionEnter(Collision col)
    {

               




        if (col.gameObject.tag.Equals("Metek"))
        {

                 //BRANJE PODATKOV IZ DATOTEKE
        string json = File.ReadAllText(Application.dataPath + "/Data/izbira.json"); //naloži podatke iz datoteke .json
        Data playerData = JsonUtility.FromJson<Data>(json); //pošlje vse podatke v razred PlayerData
        playerData.score = playerData.score + 1 ; //spremeni vrednost igralca
        
        //PISANJE PODATKOV V DATOTEKO
        string json2 = JsonUtility.ToJson(playerData); 
        //Debug.Log(json2);
        File.WriteAllText(Application.dataPath + "/Data/izbira.json", json2);


        //limit -1
        string json1 = File.ReadAllText(Application.dataPath + "/Data/limitData.json"); //naloži podatke iz datoteke .json
        Data1 playerData1 = JsonUtility.FromJson<Data1>(json1); //pošlje vse podatke v razred PlayerData
        
       playerData1.limit = playerData1.limit - 1;

       //PISANJE PODATKOV V DATOTEKO
        string json22 = JsonUtility.ToJson(playerData1); 
        //Debug.Log(json2);
        File.WriteAllText(Application.dataPath + "/Data/limitData.json", json22);
        //konec limit -1


            health = health - 1;
            audioSrc.PlayOneShot(hit_hurt);
        }
    }
}
