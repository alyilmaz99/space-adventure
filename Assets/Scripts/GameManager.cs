using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public LayerMask mask;
    //public bool collidercheck1=true;
    //public GameObject orbit1;



    public GameObject orbit1,orbit2,orbit3;
    public int orbitCount;
    public bool movementCheck;

    public bool endGameCheck;




    void Start()
    {

    }

    void Update()
    {
        MouseClick();



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
            if (Input.GetMouseButtonUp(0))
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


        }
    }

    public void EndGame()
    {
        if (orbitCount != 0)
        {
            Debug.Log("yandiniz");
            Time.timeScale = 0;
        }


        
    }
}