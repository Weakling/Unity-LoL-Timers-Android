using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach to letter buttons
// activates champion icon panel

public class LetterButton : MonoBehaviour {

    MyManager myManager;
    public int pagePosition;

    private void Awake()
    {
        myManager = FindObjectOfType<MyManager>();
    }
    
    public void MyLetterClick()
    {
        myManager.championPanelCtr = pagePosition;                      // set destination panel
        myManager.championPanelsArray[pagePosition].SetActive(true);    // activate destination panel champion page
        myManager.championPanelsArray[0].SetActive(false);              // disable letter panel
    }
}