using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Box : MonoBehaviour
{
    public int id;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject spriteMask;
    public bool maskEnabled;

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
}
