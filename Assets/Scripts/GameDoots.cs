using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoots : MonoBehaviour
{
    private AudioController audioController;
    [SerializeField] Sanity sanity;

    // music
    [SerializeField] GameObject gameSoundtrack;
    private AudioSource[] soundTrackLayers = new AudioSource[3];

    // menu sfx
    [SerializeField] GameObject pauseSfx;
    private AudioSource[] pauseSounds = new AudioSource[2];

    // light sfx
    [SerializeField] GameObject lightSfx;
    private AudioSource[] lightSounds = new AudioSource[2];

    // pipe sfx
    [SerializeField] GameObject pipeSfx;
    private AudioSource[] pipeSounds = new AudioSource[3];

    // door sfx
    [SerializeField] GameObject wallSfx;
    private AudioSource[] wallSounds = new AudioSource[2];

    // player sfx
    [SerializeField] GameObject playerSfx;
    private AudioSource[] playerSounds = new AudioSource[2];

    // monster death sfx
    [SerializeField] GameObject monsterDeathSfx;
    private AudioSource[] monsterDeathSounds = new AudioSource[5];

    // big mouth triggered sfx
    [SerializeField] GameObject bigMouthTriggeredSfx;
    private AudioSource[] bigMouthTriggeredSounds = new AudioSource[3];

    void Start()
    {
        audioController = GetComponent<AudioController>();

        // loads game soundtrack layers
        for (int i = 0; i < soundTrackLayers.Length; i++)
        {
            soundTrackLayers[i] = gameSoundtrack.GetComponents<AudioSource>()[i];
        }

        // loads pause sfx
        for (int i = 0; i < pauseSounds.Length; i++)
        {
            pauseSounds[i] = pauseSfx.GetComponents<AudioSource>()[i];
        }

        // loads light sfx
        for (int i = 0; i < lightSounds.Length; i++)
        {
            lightSounds[i] = lightSfx.GetComponents<AudioSource>()[i];
        }

        // loads pipe sfx
        for (int i = 0; i < pipeSounds.Length; i++)
        {
            pipeSounds[i] = pipeSfx.GetComponents<AudioSource>()[i];
        }

        // loads wall sfx
        for (int i = 0; i < wallSounds.Length; i++)
        {
            wallSounds[i] = wallSfx.GetComponents<AudioSource>()[i];
        }

        // loads player sfx
        for (int i = 0; i < playerSounds.Length; i++)
        {
            playerSounds[i] = playerSfx.GetComponents<AudioSource>()[i];
        }

        // loads monster death sfx
        for (int i = 0; i < monsterDeathSounds.Length; i++)
        {
            monsterDeathSounds[i] = monsterDeathSfx.GetComponents<AudioSource>()[i];
        }

        // loads big mouth triggered sfx
        for (int i = 0; i < bigMouthTriggeredSounds.Length; i++)
        {
            bigMouthTriggeredSounds[i] = bigMouthTriggeredSfx.GetComponents<AudioSource>()[i];
        }
    }

    private void Update()
    {
        soundTrackLayers[0].volume = audioController.music / 10;
        soundTrackLayers[1].volume = (audioController.music / 10) * ((sanity.maxSanity - sanity.sanity) * 0.01f);
        soundTrackLayers[2].volume = (audioController.music / 10) * (((sanity.maxSanity - sanity.sanity) * 0.01f) - (1 - sanity.critThreshold));
    }

    public void PlayPauseSound(int ind)
    {
        pauseSounds[ind].volume = (audioController.sfx / 10) / 2;
        pauseSounds[ind].Play();
    }

    public void PlayLightSound(int ind)
    {
        lightSounds[ind].volume = (audioController.sfx / 10) / 2;
        lightSounds[ind].Play();
    }

    public void PlayPipeSound()
    {
        int rng = Random.Range(0, 3);

        pipeSounds[rng].volume = (audioController.sfx / 10) / 2;
        pipeSounds[rng].Play();
    }

    public void PlayWallSound(int ind)
    {
        wallSounds[ind].volume = (audioController.sfx / 10) / 2;
        wallSounds[ind].Play();
    }

    public void PlayPlayerSound(int ind)
    {
        playerSounds[ind].volume = (audioController.sfx / 10) / 2;
        playerSounds[ind].Play();
    }

    public void PlayMonsterDeathSound(bool bigMouth)
    {
        int rng;
        if (bigMouth)
            rng = Random.Range(0, 5);
        else
            rng = Random.Range(0, 4);

        monsterDeathSounds[rng].volume = (audioController.sfx / 10) / 2;
        monsterDeathSounds[rng].Play();
    }

    public void PlayBigMouthTriggeredSound()
    {
        int rng = Random.Range(0, 3);

        bigMouthTriggeredSounds[rng].volume = (audioController.sfx / 10) / 2;
        bigMouthTriggeredSounds[rng].Play();
    }
}
