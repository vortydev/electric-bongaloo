using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PowerSourceAnimation : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Color cyclingColor = new Color(1, 0, 0);
    public float delayVal = 0.05f;
    public float incrementVal = 0.0255f;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = cyclingColor;
        StartCoroutine(CycleToYellow());
    }

    private IEnumerator CycleToYellow()
    {
        StopCoroutine(CycleToRed());
        while (cyclingColor.g < 1)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.g += incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToGreen());
    }

    private IEnumerator CycleToGreen()
    {
        StopCoroutine(CycleToYellow());
        while (cyclingColor.r > 0)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.r -= incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToCyan());
    }

    private IEnumerator CycleToCyan()
    {
        StopCoroutine(CycleToGreen());
        while (cyclingColor.b < 1)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.b += incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToBlue());
    }

    private IEnumerator CycleToBlue()
    {
        StopCoroutine(CycleToCyan());
        while (cyclingColor.g > 0)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.g -= incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToMagenta());
    }

    private IEnumerator CycleToMagenta()
    {
        StopCoroutine(CycleToBlue());
        while (cyclingColor.r < 1)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.r += incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToRed());
    }

    private IEnumerator CycleToRed()
    {
        StopCoroutine(CycleToMagenta());
        while (cyclingColor.b > 0)
        {
            yield return new WaitForSeconds(delayVal);
            cyclingColor.b -= incrementVal;
            sprite.color = cyclingColor;
        }
        StartCoroutine(CycleToYellow());
    }
}
