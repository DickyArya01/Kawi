using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlBtn;
    

    int levelPassed;

    void Start()
    {
        levelPassed = PlayerPrefs.GetInt("levelAt");

        for(int i = 0; i < lvlBtn.Length; i++)
        {
            lvlBtn[i].interactable = false;

        }

        switch (levelPassed)
        {
            case 2:
                lvlBtn[0].interactable = true;
                break;
            case 3:
                lvlBtn[0].interactable = true;
                lvlBtn[1].interactable = true;
                break;
            case 4:
                lvlBtn[0].interactable = true;
                lvlBtn[1].interactable = true;
                lvlBtn[2].interactable = true;
                break;
            case 5:
                lvlBtn[0].interactable = true;
                lvlBtn[1].interactable = true;
                lvlBtn[2].interactable = true;
                lvlBtn[3].interactable = true;
                break;
            case 6:
                lvlBtn[0].interactable = true;
                lvlBtn[1].interactable = true;
                lvlBtn[2].interactable = true;
                lvlBtn[3].interactable = true;
                lvlBtn[4].interactable = true;
                break;
        }
        
    }}
