using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyManager : MonoBehaviour {

    public static Sprite currentChampIcon;
    public static bool editMenuOn;
    public static bool championMenuOn;
    public static GameObject currentLaneIcon;
    public int numOfChampionPanels, championPanelCtr;
    public GameObject[] championPanelsArray;
    public GameObject txtSpellsEditAlert, panelTimers02, panelInspirationRunes, restartBtn;
    
    private void Awake()
    {
        editMenuOn = false;
    }
    
	void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

    public void EditMenu()
    {
        editMenuOn = !editMenuOn;

        if (editMenuOn)
        {
            panelTimers02.SetActive(false);
            panelInspirationRunes.SetActive(true);
            txtSpellsEditAlert.SetActive(true);
            restartBtn.SetActive(true);
        }
        else
        {
            panelTimers02.SetActive(true);
            panelInspirationRunes.SetActive(false);
            txtSpellsEditAlert.SetActive(false);
            restartBtn.SetActive(false);
        }
    }

    // Set active panel 0 (letter select)
    public void ChampionMenuOpen()
    {
        championPanelsArray[0].SetActive(true);   
    }

    // set icon to current champ/lane icon
    public void ChampIconSwap()
    {
        currentLaneIcon.GetComponent<Image>().sprite = currentChampIcon;
    }

    // Load scene 0 (desktop timers)
    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}