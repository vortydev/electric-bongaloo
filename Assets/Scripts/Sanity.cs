using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    private Image sanityBar;

    Color regColor = new Color(0.7f, 0.7f, 0.7f, 1);

    public float sanity = 100f;
    public float maxSanity = 100f;
    public bool isDead = false;
    public bool isSafe = true;
    public bool isDim = false;

    private void Start()
    {
        sanityBar = GetComponent<Image>();
        sanityBar.color = regColor;

        UpdateSanityBar();
    }

    private void FixedUpdate()
    {
        // if sanity reaches 0 you die
        if (sanity <= 0)
        {
            isDead = true;
            Debug.Log("Dead."); // temp
        }

        if (!isSafe)
        {
            LoseSanity(0.05f);
        }
        else if (!isDim)
        {
            GainSanity(1.0f);
        }
    }

    private void UpdateSanityBar()
    {
        float ratio = sanity / maxSanity;
        sanityBar.rectTransform.localScale = new Vector2(ratio, 1);


        if (ratio <= 0.2f)
        {
            sanityBar.CrossFadeColor(Color.red, 2.5f, true, false);
        }
        else
            sanityBar.CrossFadeColor(regColor, 0.5f, true, false);
    }

    public void LoseSanity(float damage)
    {
        if (sanity > 0)
            sanity -= damage;
        else if (sanity <= 0)
        {
            sanity = 0;
            isDead = true;
        }

        UpdateSanityBar();
    }

    public void GainSanity(float heal)
    {
        sanity += heal;

        if (sanity > maxSanity)
            sanity = maxSanity;

        UpdateSanityBar();
    }

    public void ToggleSafe()
    {
        isSafe = !isSafe;
    }
}