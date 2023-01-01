using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitController : MonoBehaviour
{

    [SerializeField] private float rotationSpeed;
    [SerializeField] private int direction;
    private Vector3 rotationVector = new Vector3(0, 0, 1);

    [SerializeField] private GameObject gameManager;


    void Start()
    {
        if(direction == 0)
        {
            rotationSpeed *= -1;
        }
        gameManager = GameObject.FindGameObjectWithTag("GameController");
    }

    
    void Update()
    {
        Rotation();

    }


    void Rotation()
    {
        transform.Rotate(rotationVector * rotationSpeed*10 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Planet")
        {
            gameManager.GetComponent<GameManager>().movementCheck = true;
        }
    }


}
