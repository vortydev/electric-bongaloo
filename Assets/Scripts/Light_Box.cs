using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Box : MonoBehaviour
{
    [SerializeField] SpriteMask mask;
    [SerializeField] SpriteRenderer spriteRenderer;
    int visibleLayer = 5;
    int hiddenLayer = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeSpriteLayer(int desiredLayer)
    {
        spriteRenderer.sortingOrder = desiredLayer;
    }

    public void TurnOn()
    {
        ChangeSpriteLayer(visibleLayer);
        mask.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
