using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Timer : MonoBehaviour {

    public int maxTime = 0; //Seconds Overall
    public Text countdown; //UI Text Object
    private int time = 0;
    public GameObject s;
    void Start()
    {
        StartCoroutine("startTime");
        Time.timeScale = 1; //Just making sure that the timeScale is right
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Barrel"))
        {
            col.gameObject.SetActive(false);
            Destroy(s);
            time += 10;
        }
       

    }

    

    void Update()
    {
        if (time > maxTime)
            countdown.text = ("You have Lost");
        else
        {
            
                countdown.text = ("" + time); //Showing the Score on the Canvas
            
        }
    }
    //Simple Co-routine
    IEnumerator startTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            time++;
        }
    }
}

