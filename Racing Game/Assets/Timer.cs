//Created By Adam Hussain

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
    private bool gameOver = false;
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

        if (col.gameObject.CompareTag("FinishLine") && time > 30)
        {
            //col.gameObject.SetActive(false);
            //Destroy(s);
            if (time < maxTime - 30)
            {
                countdown.text = ("You Won - You Beat the target time");
                gameOver = true;
            }
            else if (time > maxTime - 30)
            {
                countdown.text = ("You Lost - You took longer than the target time!");
                gameOver = true;
            }
        }

        if (col.gameObject.CompareTag("CarObject"))
        {
            col.gameObject.SetActive(false);
            Destroy(s);
            time += 20;
        }
    }

    

    void Update()
    {
        if (gameOver == false)
        {
            
                if(time < 60)
                    countdown.text = ("" + time); //Showing the Score on the Canvas     
                 else if (time > 60 && time < 120)
                    if(time < 70)
                        countdown.text = ("1:0" + (time-60));      
                    else
                        countdown.text = ("1:" + (time - 60));
                else if (time > 120 && time < 180)
                    if (time < 130)
                        countdown.text = ("2:0" + (time - 120));
                    else
                        countdown.text = ("2:" + (time - 120));
                else if (time > 180 && time < 240)
                    if (time < 190)
                        countdown.text = ("3:0" + (time - 180));
                    else
                        countdown.text = ("3:" + (time - 180));
                else if (time > 240 && time < 300)
                    if (time < 250)
                        countdown.text = ("4:0" + (time - 240));
                    else
                        countdown.text = ("4:" + (time - 240));
                else if (time > 300 && time < 360)
                    if (time < 310)
                        countdown.text = ("5:0" + (time - 300));
                    else
                        countdown.text = ("5:" + (time - 300));

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

