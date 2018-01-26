using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneIconButton : MonoBehaviour {


    MyManager myManager;

    private void Awake()
    {
        myManager = FindObjectOfType<MyManager>();
    }
    // Use this for initialization
    void Start() {

    }

    public void LaneIconClick()
    {
        MyManager.currentLaneIcon = this.gameObject;
        myManager.ChampionMenuOpen();
    }
}
