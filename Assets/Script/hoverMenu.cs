using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoverMenu : MonoBehaviour
{    // Update is called once per frame
    [SerializeField] private GameObject panelMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) ) 
        {
            if (panelMenu.active == true)
            {
                panelMenu.SetActive(false);
            }else
            {
                panelMenu.SetActive(true);
            }
        } 
    }

}
