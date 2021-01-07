using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanity : MonoBehaviour
{
    private Image sanityBar;
    [SerializeField] Animator animator;

    Color regColor = new Color(0, 0.47f, 1);

    public float sanity = 100f;
    public float maxSanity = 100f;
    public float critThreshold = 0.2f;

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

    public float SanityCheck()
    {
        return sanity;
    }

    private void UpdateSanityBar()
    {
        float ratio = sanity / maxSanity;
        sanityBar.rectTransform.localScale = new Vector2(ratio, 1);

        UpdateSanityBody();

        if (ratio <= critThreshold)
        {
            sanityBar.CrossFadeColor(Color.red, 5f, true, false);
        }
        else
        {
            sanityBar.CrossFadeColor(regColor, 0.5f, true, false);
        }
    }

    // fuuuuck me mate
    private void UpdateSanityBody()
    {
        if (sanity >= 95)
            animator.Play("SanityBody1");
        else if (sanity >= 90)
            animator.Play("SanityBody2");
        else if (sanity >= 85)
            animator.Play("SanityBody3");
        else if (sanity >= 80)
            animator.Play("SanityBody4");
        else if (sanity >= 76)
            animator.Play("SanityBody5");
        else if (sanity >= 72)
            animator.Play("SanityBody6");
        else if (sanity >= 68)
            animator.Play("SanityBody7");
        else if (sanity >= 64)
            animator.Play("SanityBody8");
        else if (sanity >= 60)
            animator.Play("SanityBody9");
        else if (sanity >= 56)
            animator.Play("SanityBody10");
        else if (sanity >= 52)
            animator.Play("SanityBody11");
        else if (sanity >= 48)
            animator.Play("SanityBody12");
        else if (sanity >= 44)
            animator.Play("SanityBody13");
        else if (sanity >= 40)
            animator.Play("SanityBody14");
        else if (sanity >= 36)
            animator.Play("SanityBody15");
        else if (sanity >= 32)
            animator.Play("SanityBody16");
        else if (sanity >= 28)
            animator.Play("SanityBody17");
        else if (sanity >= 24)
            animator.Play("SanityBody18");
        else if (sanity >= 20)
            animator.Play("SanityBody19");
        else if (sanity >= 16)
            animator.Play("SanityBody20");
        else if (sanity >= 12)
            animator.Play("SanityBody21");
        else if (sanity >= 8)
            animator.Play("SanityBody22");
        else if (sanity >= 4)
            animator.Play("SanityBody23");
        else if (sanity >= 1)
            animator.Play("SanityBody24");
        else if (sanity == 0)
            animator.Play("SanityBody25");
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