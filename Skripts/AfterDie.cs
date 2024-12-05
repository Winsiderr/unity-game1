using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterDie : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene ("Vilage");
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
