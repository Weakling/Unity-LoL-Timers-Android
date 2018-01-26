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
    //public GameObject topIcon, jgIcon, midIcon, botIcon, supIcon;
    

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

    public void ChampionMenuOpen()
    {
        //championMenuOn = !championMenuOn;

        //if(championMenuOn)
        {
            championPanelsArray[0].SetActive(true);
        }
    }

    public void ChampIconSwap()
    {
        currentLaneIcon.GetComponent<Image>().sprite = currentChampIcon;
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
