using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameSceneUIController : MonoBehaviour
{
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



    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
