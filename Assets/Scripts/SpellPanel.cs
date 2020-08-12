using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach to spell images
// set spell of target lane

public class SpellPanel : MonoBehaviour {
    public static Timers targetLane;

    public void SetBarrier()
    {
        targetLane.SetBarrier();
    }

    public void SetClense()
    {
        targetLane.SetCleanse();
    }

    public void SetExhaust()
    {
        targetLane.SetExhaust();
    }

    public void SetFlash()
    {
        targetLane.SetFlash();
    }

    public void SetGhost()
    {
        targetLane.SetGhost();
    }

    public void SetHeal()
    {
        targetLane.SetHeal();
    }

    public void SetIgnite()
    {
        targetLane.SetIgnite();
    }

    public void SetTeleport()
    {
        targetLane.SetTeleport();
    }

    public void SetSmite()
    {
        targetLane.SetSmite();
    }
}