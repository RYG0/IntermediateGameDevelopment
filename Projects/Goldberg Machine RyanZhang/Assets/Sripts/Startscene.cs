using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startscene : MonoBehaviour
{
    private bool paused = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }
    //void Awake()
    //{
        //this.fixedDeltaTime = Time.fixedDeltaTime;
    //}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            paused = !paused;
            Time.timeScale = 1;
        }
    }
}
