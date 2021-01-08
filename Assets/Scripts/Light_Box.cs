using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Box : MonoBehaviour
{
    [SerializeField] GameObject lightBoxChild;
    [SerializeField] SpriteRenderer spriteRenderer;
    int visibleLayer = 5;
    int hiddenLayer = 1;
    [SerializeField] public bool maskEnabled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeSpriteLayer(int desiredLayer)
    {
        spriteRenderer.sortingOrder = desiredLayer;
    }

    public void UseObject()
    {
        if (!maskEnabled)
        {
            TurnOn();
        }
        else TurnOff();
    }

    public void TurnOn()
    {
        ChangeSpriteLayer(visibleLayer);
        lightBoxChild.SetActive(true);
        maskEnabled = lightBoxChild.activeSelf;
    }

    public void TurnOff()
    {
        ChangeSpriteLayer(hiddenLayer);
        lightBoxChild.SetActive(false);
        maskEnabled = lightBoxChild.activeSelf;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
