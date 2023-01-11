using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stargiver : MonoBehaviour
{
    float timee; 
    public float timefor1;
    public float timefor2;
    public float timefor3;
    public List<GameObject> star;
    public int level;
    bool timer;
    void Start()
    {
        timer = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer = true){
           timee += Time.deltaTime;
           Debug.Log(timee);
        }  
    }
    public void showstar(){
        timer = false;
        if(timee > timefor1){
            star[0].SetActive(false);
            star[1].SetActive(false);
            star[2].SetActive(false);
            PlayerPrefs.SetInt("s"+level.ToString(),0);
        }
        if(timee < timefor1 && timee > timefor2){
            star[0].SetActive(true);
            star[1].SetActive(false);
            star[2].SetActive(false);
            PlayerPrefs.SetInt("s"+level.ToString(),1);
        }
        if(timee < timefor2 && timee > timefor3){
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(false);
            PlayerPrefs.SetInt("s"+level.ToString(),2);
        }
        if(timee < timefor3){
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
            PlayerPrefs.SetInt("s"+level.ToString(),3);
        }
    }
}
