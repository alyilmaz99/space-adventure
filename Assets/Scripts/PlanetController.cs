using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    

    public bool orbitChange = false;

    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 targetPosition;
    [SerializeField] private float movementSpeed;

    [SerializeField] private GameObject gameManager;
    


    void Start()
    {
        targetPosition = target.gameObject.transform.position;

        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        Movement();

    }


    void Movement()
    {
        if (orbitChange)
        {
            transform.parent = null;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Orbit")
        {
            
            orbitChange = false;
            transform.parent = other.gameObject.transform;
        }
        else if (other.gameObject.tag == "Planet")
        {

            gameManager.GetComponent<GameManager>().EndGame();
            //orbitChange = false;
        }
        else if (other.gameObject.tag == "Blackhole")
        {            
            Destroy(gameObject);
            gameManager.GetComponent<GameManager>().successCheck = true;
        }

    }


    
}