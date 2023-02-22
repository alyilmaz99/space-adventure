using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class retry : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController");
    }


    public void Retry()
    {
        gameManager.GetComponent<GameManager>().RetryButton();
    }
    
    void Update()
    {
        
    }
}
