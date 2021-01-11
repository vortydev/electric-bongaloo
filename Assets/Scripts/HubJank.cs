using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubJank : MonoBehaviour
{
    [SerializeField] GameObject[] hubLights;

    private void Start()
    {
        for (int i = 0; i < hubLights.Length; i++)
        {
            hubLights[i].SetActive(false);
        }
    }

    public void TurnOnHubLight(int ind)
    {
        hubLights[ind].SetActive(true);
    }

    public void TurnOffHubLight(int ind)
    {
        hubLights[ind].SetActive(false);
    }
}
