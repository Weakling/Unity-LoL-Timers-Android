using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseDetection : MonoBehaviour
{
    public Text txtDisplay;

    /*void Start()
    {
        // Check the number of monitors connected.
        if (Display.displays.Length > 1)
        {
            // Activate the display 1 (second monitor connected to the system).
            Display.displays[1].Activate();
        }
    }*/

    void Update()
    {
        print(Input.mousePosition);
        txtDisplay.text = Input.mousePosition.ToString();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            SetFullscreen();
        }
    }

    public void SetFullscreen()
    {
        if(Screen.fullScreenMode == FullScreenMode.FullScreenWindow)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}