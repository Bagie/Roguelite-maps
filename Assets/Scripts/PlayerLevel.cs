using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLevel : MonoBehaviour
{
    public int currentLevel;            //temp public
    public float currentExperience;   //temp public
    public float experienceToLevelUp = 100;
    public  bool gainExp = true;
    [SerializeField] float experienceMultiplier = 1f;
    [SerializeField] float experienceIncreaseOnLvlUpMultiplier = 0.1f;
    [SerializeField]int startingLevel;
    [SerializeField] int maxLevel;

    [Space]
    [SerializeField] Slider expSlider;
    [SerializeField] TMP_Text curExpText;
    [SerializeField] TMP_Text maxExpText;
    [SerializeField] TMP_Text curLvlText;

    void Start()
    {
        currentLevel = startingLevel;
        currentExperience = 0;
        expSlider.value = Mathf.Clamp01(currentExperience);
        curExpText.text = currentExperience.ToString();
        maxExpText.text = experienceToLevelUp.ToString();
        curLvlText.text = currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LevelUp()
    {
        if (currentLevel >= maxLevel)
        {
            gainExp = false;
            return;
        }

        currentLevel += 1;
        experienceToLevelUp += experienceToLevelUp  * experienceIncreaseOnLvlUpMultiplier;
        currentExperience = 0;

        expSlider.value = Mathf.Clamp01(currentExperience/experienceToLevelUp);
        curExpText.text = currentExperience.ToString();
        maxExpText.text = experienceToLevelUp.ToString();
        curLvlText.text = currentLevel.ToString();

    }

    // --==PUBLIC==- //

    public void GainExperience(float _experience)
    {
        if (gainExp == false)     //jei max lvl nebeprideti
        { return; }

        _experience *= experienceMultiplier;
       float _setExp = currentExperience + _experience;
        _setExp = Mathf.Min(_setExp, experienceToLevelUp); //reik padaryt, kad multi lvl up veiktu

        if (_setExp >= experienceToLevelUp)
        { 
            LevelUp(); 
            
        }

        else
        { 
            currentExperience = _setExp;

            expSlider.value = Mathf.Clamp01(currentExperience / experienceToLevelUp);
            curExpText.text = currentExperience.ToString();
            maxExpText.text = experienceToLevelUp.ToString();
            curLvlText.text = currentLevel.ToString();
        }


    }

  
}
