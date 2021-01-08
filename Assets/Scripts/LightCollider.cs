using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCollider : Light_Box
{
    Light_Box lightBox;

    private void Start()
    {
        lightBox = gameObject.transform.parent.gameObject.GetComponent<Light_Box>();
    }
    public bool isLightOn()
    {
        return lightBox.maskEnabled;
    }
}
