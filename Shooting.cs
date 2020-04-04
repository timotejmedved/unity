using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //dodamo knjižnico
using System;
using UnityEngine.UI;
using System.IO;

public class Shooting : MonoBehaviour
{


     

    public Rigidbody metek;
    public Transform firePoint;
    public float hitrost = 5000f;

   private class Data{
        public int score;
    }
    // Start is called before the first frame update
    void Start()
    {
         //BRANJE PODATKOV IZ DATOTEKE
        string json = File.ReadAllText(Application.dataPath + "/Data/izbira.json"); //naloži podatke iz datoteke .json
        Data playerData = JsonUtility.FromJson<Data>(json); //pošlje vse podatke v razred PlayerData
        playerData.score = 0; //spremeni vrednost igralca
        
        //PISANJE PODATKOV V DATOTEKO
        string json2 = JsonUtility.ToJson(playerData); 
        //Debug.Log(json2);
        File.WriteAllText(Application.dataPath + "/Data/izbira.json", json2);


         Cursor.visible = false;// medved
    }

    // Update is called once per frame
    void Update()
    {
          



        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Rigidbody ustvarjenMetek;

       ustvarjenMetek = Instantiate(metek, firePoint.position, firePoint.rotation) as Rigidbody;
        ustvarjenMetek.AddForce(firePoint.forward * hitrost); 
       
        
    }



  



}
