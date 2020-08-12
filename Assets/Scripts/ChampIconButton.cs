using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Attach to Champ/Lane selection icons
// Click to swap icon and close panel

public class ChampIconButton : MonoBehaviour {

    private MyManager myManager;

    public void Awake()
    {
        myManager = GameObject.FindObjectOfType<MyManager>();
    }

    public void MyClick()
    {
        MyManager.currentChampIcon = this.GetComponent<Image>().sprite;                         // set as new icon target
        myManager.ChampIconSwap();                                                              // set image to icon target
        myManager.championPanelsArray[myManager.championPanelCtr].gameObject.SetActive(false);  // turn off panel
        myManager.championPanelCtr = 0;                                                         // select panel 0
    }
}