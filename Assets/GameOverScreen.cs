using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text pointsText;
    public GameObject RandomSpawn;
    private GameObject[] gameObjects;
    private void Start() {
        RandomSpawn = GameObject.Find("RandomSpwan");
    }

    public void Setup(int score){
        DestroyAllObjects("Enemy");
        DestroyAllObjects("Hero");
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        RandomSpawn.GetComponent<RandomHero_Monster>().CancelInvoke();
    }
    public void Restart(){
        SceneManager.LoadScene("SampleScene");
        Time.fixedDeltaTime = 0.25f;
    }

    void DestroyAllObjects(string tag){
        gameObjects = GameObject.FindGameObjectsWithTag (tag);
     
        for(var i = 0 ; i < gameObjects.Length ; i ++)
        {
         Destroy(gameObjects[i]);
        }
    }
}
