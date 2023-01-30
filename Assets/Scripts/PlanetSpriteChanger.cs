using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpriteChanger : MonoBehaviour
{
    [SerializeField] private List<Sprite> planetSpriteList = new List<Sprite>();
    [SerializeField] private List<GameObject> planetList = new List<GameObject>();
     private GameObject[] planetArray;


    void Start()
    {
        SetPlanetList();
        ChangeSprite();
    }

    
    void Update()
    {
        
    }

    void SetPlanetList()
    {
        planetArray = GameObject.FindGameObjectsWithTag("Planet");
        foreach (GameObject gameObject in planetArray)
        {
            planetList.Add(gameObject);
        }
    }
    void ChangeSprite()
    {
        for(int i = 0; i < planetList.Count; i++)
        {
            int spriteNumber = Random.Range(0, planetSpriteList.Count);

            planetList[i].gameObject.GetComponent<SpriteRenderer>().sprite=planetSpriteList[spriteNumber];

        }
    }

}
