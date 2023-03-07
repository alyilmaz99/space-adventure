using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject SettingsScreen;
    [SerializeField] private GameObject LevelsScreen;

    [SerializeField] private int sceneIndexNumber;
    


    [Header("sound/Vib Settings")]
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject vibButton;
    [SerializeField] private List<Sprite> soundSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> vibSpriteList = new List<Sprite>();

    [SerializeField] private bool soundFixer;
    [SerializeField] private bool vibFixer;


    void Start()
    {
        StartSoundVibCheck();

        sceneIndexNumber=PlayerPrefs.GetInt("SceneNumber");

        

    }

    
    void Update()
    {
        SoundVibUpdate();
    }



    public void StartButton()
    {
        if (PlayerPrefs.HasKey("SceneNumber"))
        {
            SceneManager.LoadScene(sceneIndexNumber);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public void OpenSettings()
    {
        SettingsScreen.SetActive(true);
    }
    public void CloseSettings()
    {
        SettingsScreen.SetActive(false);
    }


    public void SoundButton()
    {
        soundFixer = !soundFixer;
    }
    public void VibButton()
    {
        vibFixer = !vibFixer;
    }

    ////////////////// Test ////////////////////////////////
    public void DenemeLevelButton()
    {
        SceneManager.LoadScene(1);
    }
    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    ////////////////////////////////////////////////


    void SoundVibUpdate()
    {
        if (soundFixer)
        {
            PlayerPrefs.SetInt("sound", 1);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[1];
        }
        else if (!soundFixer)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundButton.GetComponent<Image>().sprite = soundSpriteList[0];
        }

        if (vibFixer)
        {
            PlayerPrefs.SetInt("vib", 1);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[1];
        }
        else if (!vibFixer)
        {
            PlayerPrefs.SetInt("vib", 0);
            vibButton.GetComponent<Image>().sprite = vibSpriteList[0];
        }

    }

    void StartSoundVibCheck()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            soundFixer = true;
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            soundFixer = false;
        }

        if (PlayerPrefs.GetInt("vib") == 1)
        {
            vibFixer = true;
        }
        else if (PlayerPrefs.GetInt("vib") == 0)
        {
            vibFixer = false;
        }
    }


    public void openLevelScreen()
    {
        LevelsScreen.gameObject.SetActive(true);
    }

    public void closeLevelScreen()
    {
        LevelsScreen.gameObject.SetActive(false);
    }



}
