using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelbuttonscript : MonoBehaviour
{

    // Y�ld�z say�s� Planetcontrol scripti i�inde blackhole ile temas edilince kazan�l�yor.
    //Her levele girildi�inde MaxLevel playerprefs kontrol ediliyor. Activescene numberdan b�y�kse maxlevel say�m�z art�yor.
    //Kilidi kald�r�yoruz



    public int levelno;
    public int level;
    public GameObject lockk;
    bool avaliable;
    public GameObject[] star;
    int stars;
    public Text number;
    void Start()
    {
        lockk.SetActive(true);
        avaliable = false;
        star[0].SetActive(false);
        star[1].SetActive(false);
        star[2].SetActive(false);
        levelButtonFixer();
    }


    void levelButtonFixer()
    {
        levelno = PlayerPrefs.GetInt("MaxLevel");
        stars = PlayerPrefs.GetInt("s" + level.ToString());
        number.text = level.ToString();
        if (level <= levelno)
        {
            lockk.SetActive(false);
            avaliable = true;
        }
        if (level > levelno)
        {
            lockk.SetActive(true);
            avaliable = false;
        }
        if (stars == 0)
        {
            star[0].SetActive(false);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }
        if (stars == 1)
        {
            star[0].SetActive(true);
            star[1].SetActive(false);
            star[2].SetActive(false);
        }
        if (stars == 2)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(false);
        }
        if (stars == 3)
        {
            star[0].SetActive(true);
            star[1].SetActive(true);
            star[2].SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
