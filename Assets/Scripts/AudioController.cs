using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // audio settings
    public float music;
    public float sfx;

    void Start()
    {
        // loads controller's variable from PlayerPrefs
        music = PlayerPrefs.GetFloat("music");
        sfx = PlayerPrefs.GetFloat("sfx");
    }

    public void UpdateMusic(float m)
    {
        if (music != m)
        {
            music = m;
            PlayerPrefs.SetFloat("music", m);
            PlayerPrefs.Save();
        }
    }

    public void UpdateSfx(float s)
    {
        if (sfx != s)
        {
            sfx = s;
            PlayerPrefs.SetFloat("sfx", s);
            PlayerPrefs.Save();
        }
    }
}
