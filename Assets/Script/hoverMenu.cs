using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverMenu : MonoBehaviour
{    // Update is called once per frame
    [SerializeField] private GameObject panelMenu;

    [SerializeField] private bool isPauseMenu;

    void Update()
    {
        if(isPauseMenu == true)
        {
            PauseMenu();
        }else {
            if(panelMenu.active == true && Input.GetKeyDown(KeyCode.Escape))
            {
                panelMenu.SetActive(false);
            }

        }

    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) ) 
        {
            if (panelMenu.active == true)
            {
                panelMenu.SetActive(false);
                Time.timeScale = 1;
            }else
            {
                panelMenu.SetActive(true);
                Time.timeScale = 0;
            }
        } 

    }

    public void openMenu()
    {
         panelMenu.SetActive(true);

    }

    public void resumeGame()
    {
         panelMenu.SetActive(false);
         Time.timeScale = 1;

    }

}
