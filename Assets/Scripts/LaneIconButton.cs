using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach to Lane Icon
// Click to set as current icon in MyManager
// Opens Champion Menu

public class LaneIconButton : MonoBehaviour {
    MyManager myManager;

    private void Awake()
    {
        myManager = FindObjectOfType<MyManager>();
    }
    
    public void LaneIconClick()
    {
        MyManager.currentLaneIcon = this.gameObject;
        if(MyManager.editMenuOn)
        {
            myManager.ChampionMenuOpen();
        }
    }
}