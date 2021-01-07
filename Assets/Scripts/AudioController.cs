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
        }
    }

    public void UpdateSfx(float s)
    {
        if (sfx != s)
        {
            sfx = s;
        }
    }

    public void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("music", music);
        PlayerPrefs.SetFloat("sfx", music);
        PlayerPrefs.Save();
    }
}
