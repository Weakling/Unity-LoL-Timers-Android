using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChampIconButton : MonoBehaviour {

    private MyManager myManager;

    public void Awake()
    {
        myManager = GameObject.FindObjectOfType<MyManager>();
    }

    public void MyClick()
    {
        //myManager.panelTimers02.SetActive(true);
        MyManager.currentChampIcon = this.GetComponent<Image>().sprite;
        myManager.ChampIconSwap();
        myManager.championPanelsArray[myManager.championPanelCtr].gameObject.SetActive(false);
        myManager.championPanelCtr = 0;
    }
}
