using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alien : MonoBehaviour
{
    public bool triggered;
    public GameObject alien;
    float startTime;
    float sceneStart;
    // Start is called before the first frame update
    void Awake()
    {
        sceneStart = Time.time;
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered && startTime + 2 < Time.time)
        {
            alien.SetActive(false);
        }
    }
    public void Aliened()
    {
        if (!triggered && sceneStart + 1 < Time.time)
        {
            alien.SetActive (true);
            startTime = Time.time;
            sceneStart = Time.time;
            triggered = true;
        }
        if (triggered && sceneStart + 2 < Time.time)
        {
            SceneManager.LoadScene("End");

        }
    }
}
