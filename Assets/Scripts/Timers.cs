using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timers : MonoBehaviour {


    // panel
    public GameObject myPanel;
    private bool panelOn;

    //spell
    public Image GOSpell01, GOSpell02;
    public GameObject spellPanel01, spellPanel02;
    public Image currentSpell;
    public Sprite[] spells;

    // timer
    public string position;
    public Text txtTimer01, txtTimer02;
    public Text currentTxtTimer;
    private float timer01Time, timer02Time;
    private float currentTimer;
    private bool timer01on, timer02on;

    // CDR
    public GameObject bootsPanel, bookPanel, insightPanel;
    public bool hasBoots, hasBook, hasInsight;
    private float bootsCDR, bookCDR, insightCDR, totalCDR;

    private float barrierTime, cleanseTime, exhaustTime, flashTime, ghostTime, healTime, igniteTime, teleportTime, currentSpellTime, smiteTime;
    

    void Start()
    {
        barrierTime = 180f;
        cleanseTime = 210f;
        exhaustTime = 210f;
        flashTime = 300f;
        ghostTime = 180f;
        healTime = 240f;
        igniteTime = 210f;
        teleportTime = 300f;
        smiteTime = 0f;

        bootsCDR = .1f;
        bookCDR = .25f;
        insightCDR = .05f;

        if(position == "Top")
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

        if(spellPanel01.activeSelf)
        {
            spellPanel01.SetActive(false);
        }
        if(spellPanel02.activeSelf)
        {
            spellPanel02.SetActive(false);
        }

    }


    void Update()
    {

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


    }


    // set spells

    public void SetSpell01()
    {
        if(MyManager.editMenuOn)
        {
            currentSpell = GOSpell01;
            currentTxtTimer = txtTimer01;
            myPanel.SetActive(true);
            panelOn = true;
            SpellPanel.targetLane = this.gameObject.GetComponent<Timers>();
        }
        else
        {
            Spell01();
        }
        
    }

    public void SetSpell02()
    {
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

    public void SetBarrier()
    {
        currentSpell.sprite = spells[0];
        currentSpellTime = barrierTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetCleanse()
    {
        currentSpell.sprite = spells[1];
        currentSpellTime = cleanseTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetExhaust()
    {
        currentSpell.sprite = spells[2];
        currentSpellTime = exhaustTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetFlash()
    {
        currentSpell.sprite = spells[3];
        currentSpellTime = flashTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetGhost()
    {
        currentSpell.sprite = spells[4];
        currentSpellTime = ghostTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetHeal()
    {
        currentSpell.sprite = spells[5];
        currentSpellTime = healTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetIgnite()
    {
        currentSpell.sprite = spells[6];
        currentSpellTime = igniteTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetTeleport()
    {
        currentSpell.sprite = spells[7];
        currentSpellTime = teleportTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    public void SetSmite()
    {
        currentSpell.sprite = spells[8];
        currentSpellTime = smiteTime;
        CheckCD();
        myPanel.SetActive(false);
        panelOn = false;
    }

    
    // set CDRs

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


    // calculations

    public void CheckCD()
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

    public void CalculateCDR()
    {
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


    // spells

    public void Spell01()
    {
        if (timer01on)
        {
            StopTimer01();
        }
        else
        {
            StartTimer01();
        }
            
    }

    public void Spell01TimerClick()
    {
        if (timer01on)
        {
            timer01Time -= 10f;
        }
        else
        {
            StartTimer01();
        }
    }

    public void Spell02()
    {
        if (timer02on)
        {
            StopTimer02();
        }
        else
        {
            StartTimer02();
        }
    }

    public void Spell02TimerClick()
    {
        if (timer02on)
        {
            timer02Time -= 10f;
        }
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