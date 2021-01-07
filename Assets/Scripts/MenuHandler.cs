using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    // menu "pages"
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject creditsMenu;
    [SerializeField] GameObject optionsMenu;

    [SerializeField] MenuDoots doot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!mainMenu.active)
            {
                if (creditsMenu.active)
                    creditsMenu.SetActive(false);
                else if (optionsMenu.active)
                    optionsMenu.SetActive(false);

                mainMenu.SetActive(true);

                doot.PlayMenuBack();
            }
        }
    }
}
