using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTimer : MonoBehaviour
{
    // timers
    public GameObject greyOutPanel;             
    public Text txtTimer;                   
    private float timerTime;
    public float objectiveTime;
    private bool objectiveTimerRunning;
    

    void Start()
    {
        // remove grey out panel
        if (greyOutPanel.activeSelf)
        {
            greyOutPanel.SetActive(false);
        }

        // set timer
        timerTime = objectiveTime;
        txtTimer.text = timerTime.ToString();
    }


    void Update()
    {
        #region timer countdown if running
        if (objectiveTimerRunning)
        {
            timerTime -= Time.deltaTime;
            txtTimer.text = Mathf.RoundToInt(timerTime).ToString();
            if (timerTime <= 0)
            {
                StopObjectiveTimer();
            }
        }
        #endregion
    }

    public void Timer()
    {
        // TIMER RUNNING stop timer
        if (objectiveTimerRunning)
        {
            StopObjectiveTimer();
        }
        // ELSE start timer
        else
        {
            StartObjectiveTimer();
        }
    }

    public void ObjectiveTimerClick()
    {
        // TIMER RUNNING subtract time
        if (objectiveTimerRunning)
        {
            timerTime -= 10f;
        }
        // ELSE start timer
        else
        {
            StartObjectiveTimer();
        }
    }



    // reference spell methods

    private void StartObjectiveTimer()
    {
        greyOutPanel.SetActive(true);
        timerTime = float.Parse(txtTimer.text);
        objectiveTimerRunning = true;
    }

    private void StopObjectiveTimer()
    {
        greyOutPanel.SetActive(false);
        objectiveTimerRunning = false;
        timerTime = objectiveTime;
        txtTimer.text = timerTime.ToString();

    }

}