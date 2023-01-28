using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScreen : MonoBehaviour
{

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void levelButton()
    {
        int scenenumber = gameObject.GetComponent<levelbuttonscript>().level;
        //SceneManager.LoadScene(scenenumber+2);
        Debug.Log("scene number : " + scenenumber);
    }


}
