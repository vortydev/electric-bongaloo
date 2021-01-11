using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubJank : MonoBehaviour
{
    [SerializeField] GameObject[] hubLights;
    [SerializeField] GameObject[] decorations;

    private void Start()
    {
        for (int i = 0; i < hubLights.Length; i++)
        {
            hubLights[i].SetActive(false);
        }

        for (int i = 1; i < decorations.Length; i++)
        {
            decorations[i].SetActive(false);
        }
    }

    public void TurnOnHubLight(int ind)
    {
        hubLights[ind].SetActive(true);

        switch (ind)
        {
            case 0:
                decorations[1].SetActive(true);     // spawns Beary Brown
                break;

            case 1:
                decorations[2].SetActive(true);     // spawns night stand
                break;

            case 2:
                decorations[3].SetActive(true);     // spawn flower pot
                break;

            case 3:
                if (!decorations[4].activeSelf) {
                    decorations[0].SetActive(false);    // disable  reg bed
                    decorations[2].SetActive(false);    // disable night stand
                    decorations[4].SetActive(true);     // enable hostpital bed
                    decorations[5].SetActive(true);     // enable table
                }
                break;
        }
    }

    public void TurnOffHubLight(int ind)
    {
        hubLights[ind].SetActive(false);

        switch (ind)
        {
            case 0:
                decorations[1].SetActive(false);     // spawns Beary Brown
                break;

            case 1:
                decorations[2].SetActive(false);     // spawns night stand
                break;

            case 2:
                decorations[3].SetActive(false);     // spawn flower pot
                break;

            case 3:
                if (decorations[4].activeSelf)
                {
                    decorations[0].SetActive(true);     // disable  reg bed
                    decorations[2].SetActive(true);     // disable night stand
                    decorations[4].SetActive(false);    // enable hostpital bed
                    decorations[5].SetActive(false);    // enable table
                }
                break;
        }
    }
}
