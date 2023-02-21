using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    


    [SerializeField] private int sceneIndexNumber;

    public GameObject orbit1,orbit2,orbit3,orbit4,orbit5;
    public int orbitCount;
    public bool movementCheck;

    public bool endGameCheck;

    public bool successCheck;

    [Header("UI Settings")]
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject successScreen;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject settingsScreen;
    [SerializeField] private GameObject pauseButton;

    [Header("sound/Vib Settings")]
    [SerializeField] private GameObject soundButton;
    [SerializeField] private GameObject vibButton;
    [SerializeField] private List<Sprite> soundSpriteList = new List<Sprite>();
    [SerializeField] private List<Sprite> vibSpriteList = new List<Sprite>();
    
    [SerializeField] private bool soundFixer;
    [SerializeField] private bool vibFixer;


    [Header("Ads Settings")]
    [SerializeField] private GameObject gameManager;



    [Header("Reborn Settings")]
    
    [SerializeField] private List<GameObject> orbitList = new List<GameObject>();
    [SerializeField] private List<GameObject> lastOrbitList = new List<GameObject>();
    private GameObject[] orbitArray;
    [SerializeField] private List<Vector2> orbitTransformList = new List<Vector2>();
    [SerializeField] private GameObject lastOrbit;
    [SerializeField] private int lastOrbitCount;





    void Start()
    {
        //Level Screen Lock System
        if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("MaxLevel"))
        {

            PlayerPrefs.SetInt("MaxLevel", SceneManager.GetActiveScene().buildIndex-4);
        }


        gameManager = GameObject.FindGameObjectWithTag("GameController");


        sceneIndexNumber = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneNumber", sceneIndexNumber);
        

        StartSoundVibCheck();
        Time.timeScale = 1;

        SetOrbitList();

    }

    void Update()
    {
        MouseClick();

        SoundVibUpdate();

        SuccessScreen();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           SetRebornPositions();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
           RebornExp();
        }

        //Debug.Log(orbitTransformList[0].transform.position);

        //if (collidercheck1)
        //{
        //    orbit1.GetComponent<CapsuleCollider>().enabled = true;
        //}

        //else if (!collidercheck1)
        //{
        //    orbit1.GetComponent<CapsuleCollider>().enabled = false;
        //}





    }


    //void MouseClick()
    //{
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Debug.Log("ilk");
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, mask))
    //        {
    //            Debug.Log("ikii");

    //            if (!hit.collider.gameObject.GetComponent<PlanetController>().orbitChange)
    //            {
    //                Debug.Log("denee");
    //                hit.collider.gameObject.GetComponent<PlanetController>().orbitChange=true;
    //            }

                
    //        }
    //    }
    //}


    void MouseClick()
    {
        if (movementCheck)
        {
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                movementCheck = false;
                OrbitChange();
            }
        }
        
    }


    void OrbitChange()
    {
        switch (orbitCount)
        {
            case 1:
                
                orbitCount -= 1;
                orbit1.GetComponent<CapsuleCollider>().enabled = false;
                for (int i = 0; i < orbit1.transform.childCount; i++)
                {
                    GameObject child = orbit1.transform.GetChild(i).gameObject;
                    child.GetComponent<PlanetController>().orbitChange = true;
                }
                break;
            case 2:
                
                orbitCount -= 1;
                orbit2.GetComponent<CapsuleCollider>().enabled = false;
                for (int i = 0; i < orbit2.transform.childCount; i++)
                {
                    GameObject child = orbit2.transform.GetChild(i).gameObject;
                    child.GetComponent<PlanetController>().orbitChange = true;
                }
                break;
            case 3:
                orbitCount -= 1;
                for (int i = 0; i < orbit3.transform.childCount; i++)
                {
                    GameObject child = orbit3.transform.GetChild(i).gameObject;
                    child.GetComponent<PlanetController>().orbitChange = true;
                }
                break;
            case 4:
                orbitCount -= 1;
                for (int i = 0; i < orbit4.transform.childCount; i++)
                {
                    GameObject child = orbit4.transform.GetChild(i).gameObject;
                    child.GetComponent<PlanetController>().orbitChange = true;
                }
                break;
            case 5:
                orbitCount -= 1;
                for (int i = 0; i < orbit5.transform.childCount; i++)
                {
                    GameObject child = orbit5.transform.GetChild(i).gameObject;
                    child.GetComponent<PlanetController>().orbitChange = true;
                }
                break;

        }
    }

    public void EndGame()
    {
        if (orbitCount != 0)
        {
            Debug.Log("yandiniz");
            Time.timeScale = 0;
            endScreen.gameObject.SetActive(true);
        }
    }

    void SuccessScreen()
    {
        if (successCheck)
        {
            successScreen.gameObject.SetActive(true);
        }
    }


    #region UI

    public void openPauseScreen()
    {
        Time.timeScale = 0;
        pauseScreen.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);

    }
    public void closePauseScreen()
    {
        Time.timeScale = 1;
        pauseScreen.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void openSettingsScreen()
    {
        
        settingsScreen.gameObject.SetActive(true);
    }

    public void closeSettingsScreen()
    {

        settingsScreen.gameObject.SetActive(false);
    }

    public void returnToMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    // lose screen Continue Button

    public void RetryButton()
    {
        gameManager.GetComponent<rewardads>().WatchRebornAd();

       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    


    #endregion

    #region Sound-Vib Controller

    public void SoundButton()
    {
        soundFixer = !soundFixer;
    }
    public void VibButton()
    {
        vibFixer = !vibFixer;
    }


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
        else if(!vibFixer)
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

    #endregion

    #region Ads Settings

    private void Reborn(object sender, Reward e)
    {
        Debug.Log("yeniden dogdu");
        pauseButton.SetActive(true);

        Time.timeScale = 1;
    }

    public void SetRebornPositions()
    {
        orbitTransformList.Clear();
        lastOrbit = orbitList[orbitCount - 1];

        for (int i = 0; i < lastOrbit.transform.childCount; i++)
        {
            GameObject child = lastOrbit.transform.GetChild(i).gameObject;
            orbitTransformList.Add(child.transform.position);
            lastOrbitList.Add(child);
            lastOrbitCount = orbitCount;
        }
    }

    public void RebornExp()
    {
        for (int i = 0; i < lastOrbitList.Count; i++)
        {
            lastOrbitList[i].transform.position = orbitTransformList[i];
            lastOrbitList[i].transform.parent = lastOrbit.transform;
            orbitCount = lastOrbitCount;

        }
    }

    private void SetOrbitList()
    {
        orbitArray = GameObject.FindGameObjectsWithTag("Orbit");
        foreach (GameObject gameObject in orbitArray)
        {
            orbitList.Add(gameObject);
        }
    }



    #endregion

}