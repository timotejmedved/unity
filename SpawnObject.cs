using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///


//using System;
using UnityEngine.UI;
using System.IO;
///
/*
Timotej Medved
3.4.2020
*/
public class SpawnObject : MonoBehaviour
{
    public GameObject AnimalPrefab;
    public Vector3 center;
    public Vector3 size;
    //public Quaternion min;
    float elapsed = 0f;


     private class Data1{
       
        public int limit;
        public int limitOnStart;
    }
       
        public int limit1;
        public int limitOnStart1;
  
    // Start is called before the first frame update
    void Start()
    {
        SpawnAnimal();

      string json = File.ReadAllText(Application.dataPath + "/Data/limitData.json"); //naloži podatke iz datoteke .json
        Data1 playerData = JsonUtility.FromJson<Data1>(json); //pošlje vse podatke v razred PlayerData
        
       playerData.limit = 0;

       //PISANJE PODATKOV V DATOTEKO
        string json2 = JsonUtility.ToJson(playerData); 
        //Debug.Log(json2);
        File.WriteAllText(Application.dataPath + "/Data/limitData.json", json2);
    }

    // Update is called once per frame
    void Update()
    {
        //get data
         //BRANJE PODATKOV IZ DATOTEKE
        string json = File.ReadAllText(Application.dataPath + "/Data/limitData.json"); //naloži podatke iz datoteke .json
        Data1 playerData = JsonUtility.FromJson<Data1>(json); //pošlje vse podatke v razred PlayerData
        
       // limit1 = playerData.limit;
        //get data end


      
        if(Input.GetKey(KeyCode.Q)){
           // SpawnAnimal();
        }


        //vsakih 5 sekund
        elapsed += Time.deltaTime;
         if (elapsed >= 3f) {
         elapsed = elapsed % 1f;
         
        if(playerData.limit<playerData.limitOnStart){
         SpawnAnimal();
         //Debug.Log("test");
         playerData.limit = playerData.limit + 1;
         //PISANJE PODATKOV V DATOTEKO
        string json2 = JsonUtility.ToJson(playerData); 
        //Debug.Log(json2);
        File.WriteAllText(Application.dataPath + "/Data/limitData.json", json2);
         }
     }
    }

 

    public void SpawnAnimal(){
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2),0,Random.Range(-size.z / 2 , size.z / 2));

        Instantiate(AnimalPrefab, pos, Quaternion.identity);
        

    }

    void OnDrawGizmosSelected(){
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }


}
