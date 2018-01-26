using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterButton : MonoBehaviour {

    MyManager myManager;
    public int pagePosition;

    private void Awake()
    {
        myManager = FindObjectOfType<MyManager>();
    }
    


    public void MyLetterClick()
    {
        myManager.championPanelCtr = pagePosition;
        myManager.championPanelsArray[pagePosition].SetActive(true);
        myManager.championPanelsArray[0].SetActive(false);
    }
}
