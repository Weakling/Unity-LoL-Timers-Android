using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour {
    
    // spell select panel
    public GameObject myPanel;                      // spell select panel
    private bool panelOn;                           // panel on

    //spell
    public Image GOSpell01, GOSpell02;              // icon
    public GameObject spellPanel01, spellPanel02;   // grey out
    [HideInInspector] public Image currentSpell;    // 
    public Sprite[] spells;                         // 

    // timers
    public string position;                         // which timer
    public Text txtTimer01, txtTimer02;             // timer text
    public Text currentTxtTimer;                    // 
    private float timer01Time, timer02Time;         // timer time
    private float currentTimer;                     // 
    private bool timer01on, timer02on;              // timer running

    // CDR
    public GameObject bootsPanel, bookPanel, insightPanel;
    public bool hasBoots, hasBook, hasInsight;
    private float bootsCDR, bookCDR, insightCDR, totalCDR;

    // Spell Cooldowns
    private float barrierTime, cleanseTime, exhaustTime, 
        flashTime, ghostTime, healTime, igniteTime, 
        teleportTime, currentSpellTime, smiteTime;
    

    void Start()
    {
        #region spell times/CDR
        igniteTime = 180f;
        barrierTime = 180f;
        ghostTime = 210f;
        exhaustTime = 210f;
        cleanseTime = 210f;
        healTime = 240f;
        flashTime = 300f;
        teleportTime = 300f;
        smiteTime = 0f;

        bootsCDR = .1f;
        bookCDR = .25f;
        insightCDR = .05f;
        #endregion

        #region default spell positions
        if (position == "Top")
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            SetFlash();
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            SetTeleport();
        }
        else if(position == "Jungle")
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            SetFlash();
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            SetSmite();
        }
        else if(position == "Mid")
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            SetFlash();
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            SetIgnite();
        }
        else if(position == "Bot")
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            SetFlash();
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            SetHeal();
        }
        else if(position == "Support")
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            SetFlash();
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            SetExhaust();
        }
        #endregion

        #region disable grey out image
        if (spellPanel01.activeSelf)
        {
            spellPanel01.SetActive(false);
        }
        if(spellPanel02.activeSelf)
        {
            spellPanel02.SetActive(false);
        }
        #endregion
    }


    void Update()
    {
        #region timers countdown if on
        if(timer01on)
        {
            timer01Time -= Time.deltaTime;
            txtTimer01.text = Mathf.RoundToInt(timer01Time).ToString();
            if(timer01Time <= 0)
            {
                StopTimer01();
            }
        }

        if(timer02on)
        {
            timer02Time -= Time.deltaTime;
            txtTimer02.text = Mathf.RoundToInt(timer02Time).ToString();
            if(timer02Time <= 0)
            {
                StopTimer02();
            }
        }
        #endregion
    }


    #region SET SPELLS
    public void SetSpell01()
    {
        // IF EDITING set spell
        if(MyManager.editMenuOn)
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            myPanel.SetActive(true);
            panelOn = true;
            SpellPanel.targetLane = this.gameObject.GetComponent<Timers>();
        }
        // ELSE start timer
        else
        {
            Spell01();
        }
    }

    public void SetSpell02()
    {
        // IF EDITING
        if(MyManager.editMenuOn)
        {
            currentSpell = GOSpell02;
            currentTxtTimer = txtTimer02;
            myPanel.SetActive(true);
            panelOn = true;
            SpellPanel.targetLane = this.gameObject.GetComponent<Timers>();
        }
        else
        {
            Spell02();
        }
    }

    void SetSpellGeneric()
    {
        //SetNewSpellAndCheckCDR();
        CalculateCDR();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetBarrier()
    {
        currentSpell.sprite = spells[0];
        currentSpellTime = barrierTime;
        SetSpellGeneric();
    }

    public void SetCleanse()
    {
        currentSpell.sprite = spells[1];
        currentSpellTime = cleanseTime;
        SetSpellGeneric();
    }

    public void SetExhaust()
    {
        currentSpell.sprite = spells[2];
        currentSpellTime = exhaustTime;
        SetSpellGeneric();
    }

    public void SetFlash()
    {
        currentSpell.sprite = spells[3];
        currentSpellTime = flashTime;
        SetSpellGeneric();
    }

    public void SetGhost()
    {
        currentSpell.sprite = spells[4];
        currentSpellTime = ghostTime;
        SetSpellGeneric();
    }

    public void SetHeal()
    {
        currentSpell.sprite = spells[5];
        currentSpellTime = healTime;
        SetSpellGeneric();
    }

    public void SetIgnite()
    {
        currentSpell.sprite = spells[6];
        currentSpellTime = igniteTime;
        SetSpellGeneric();
    }

    public void SetTeleport()
    {
        currentSpell.sprite = spells[7];
        currentSpellTime = teleportTime;
        SetSpellGeneric();
    }

    public void SetSmite()
    {
        currentSpell.sprite = spells[8];
        currentSpellTime = smiteTime;
        SetSpellGeneric();
    }
    #endregion

    #region SET CDRs
    #region old set book CDR
    public void SetBook()
    {
        if(bookPanel.activeSelf == true)
        {
            bookPanel.SetActive(false);
            hasBook = true;
        }
        else
        {
            bookPanel.SetActive(true);
            hasBook = false;
        }
        CalculateCDR();
    }
    #endregion
    #region old set CDR regardless of timer
    public void SetNewSpellAndCheckCDR()
    {
        totalCDR = 0;
        if(hasBoots)
        {
            totalCDR += bootsCDR;
        }
        if(hasBook)
        {
            totalCDR += bookCDR;
        }
        if(hasInsight)
        {
            totalCDR += insightCDR;
        }
        
        currentSpellTime -= (currentSpellTime * totalCDR);
        currentTxtTimer.text = currentSpellTime.ToString();
    }
    #endregion

    public void SetBoots()
    {
        if (bootsPanel.activeSelf == true)
        {
            bootsPanel.SetActive(false);
            hasBoots = true;
        }
        else
        {
            bootsPanel.SetActive(true);
            hasBoots = false;
        }
        CalculateCDR();
    }

    public void SetInsight()
    {
        if (insightPanel.activeSelf == true)
        {
            insightPanel.SetActive(false);
            hasInsight = true;
        }
        else
        {
            insightPanel.SetActive(true);
            hasInsight = false;
        }
        CalculateCDR();
    }

    public void CalculateCDR()
    {
        // waits for spell timers to end before applying CDR
        totalCDR = 0;
        if (hasBoots)
        {
            totalCDR += bootsCDR;
        }
        if (hasBook)
        {
            totalCDR += bookCDR;
        }
        if (hasInsight)
        {
            totalCDR += insightCDR;
        }

        if (!timer01on)
        {
            currentSpell = GOSpell01;
            txtTimer01.text = (CalculateSpellTime() - (CalculateSpellTime() * totalCDR)).ToString();
        }
        if (!timer02on)
        {
            currentSpell = GOSpell02;
            txtTimer02.text = (CalculateSpellTime() - (CalculateSpellTime() * totalCDR)).ToString();
        }
    }

    public float CalculateSpellTime()
    {
        if (currentSpell.sprite == spells[0])
        {
            return 180f;
        }
        else if(currentSpell.sprite == spells[1])
        {
            return 210f;
        }
        else if(currentSpell.sprite == spells[2])
        {
            return 210f;
        }
        else if(currentSpell.sprite == spells[3])
        {
            return 300f;
        }
        else if(currentSpell.sprite == spells[4])
        {
            return 180f;
        }
        else if (currentSpell.sprite == spells[5])
        {
            return 240f;
        }
        else if(currentSpell.sprite == spells[6])
        {
            return 210f;
        }
        else if(currentSpell.sprite == spells[7])
        {
            return 300f;
        }

        else return 0f;
    }
    #endregion

    
    public void Spell01()
    {
        // TIMER RUNNING stop timer
        if (timer01on)
        {
            StopTimer01();
        }
        // ELSE start timer
        else
        {
            StartTimer01();
        }
    }

    public void Spell01TimerClick()
    {
        // TIMER RUNNING subtract time
        if (timer01on)
        {
            timer01Time -= 10f;
        }
        // ELSE start timer
        else
        {
            StartTimer01();
        }
    }

    public void Spell02()
    {
        // TIMER RUNNING stop timer
        if (timer02on)
        {
            StopTimer02();
        }
        // ELSE start timer
        else
        {
            StartTimer02();
        }
    }

    public void Spell02TimerClick()
    {
        // TIMER RUNNING subtract time
        if (timer02on)
        {
            timer02Time -= 10f;
        }
        // ELSE start timer
        else
        {
            StartTimer02();
        }
    }


    // reference spell methods

    private void StartTimer01()
    {
        spellPanel01.SetActive(true);
        timer01Time = float.Parse(txtTimer01.text);
        timer01on = true;
    }

    private void StartTimer02()
    {
        spellPanel02.SetActive(true);
        timer02Time = float.Parse(txtTimer02.text);
        timer02on = true;
    }

    private void StopTimer01()
    {
        spellPanel01.SetActive(false);
        timer01on = false;
        CalculateCDR();
    }

    private void StopTimer02()
    {
        spellPanel02.SetActive(false);
        timer02on = false;
        CalculateCDR();
    }

}