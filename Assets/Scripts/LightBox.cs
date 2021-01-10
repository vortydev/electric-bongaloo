using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBox : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject spriteMask;
    public bool maskEnabled;

    [SerializeField] Pipe[] requiredPipes;

    private int visibleLayer = 5;
    private int hiddenLayer = 1;

    private void ChangeSpriteLayer(int desiredLayer)
    {
        spriteRenderer.sortingOrder = desiredLayer;
    }

    public void TurnOn()
    {
        ChangeSpriteLayer(visibleLayer);
        spriteMask.SetActive(true);
        maskEnabled = spriteMask.activeSelf;
    }

    public void TurnOff()
    {
        ChangeSpriteLayer(hiddenLayer);
        spriteMask.SetActive(false);
        maskEnabled = spriteMask.activeSelf;
    }

    public void CheckLightBoxPowered()
    {
        int poweringPipes = 0;

        for (int i = 0; i < requiredPipes.Length; i++)
        {
            if (requiredPipes[i].isGucci)
                poweringPipes++;
        }

        if (poweringPipes == requiredPipes.Length)
            TurnOn();
        else
            TurnOff();
    }
}
