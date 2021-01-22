using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource audioEffects;
    public AudioClip playerJumpSound, playerDieSound, playerSlideSound;
    public Slider musicSlider;
    public Slider soundSlider;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("SoundVolume"))
        {
            ChangeMusicVolume(PlayerPrefs.GetFloat("SoundVolume"));
            if (soundSlider != null)
            {
                soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
            }
        }
        else
        {
            ChangeSoundVolume(1f);
            SaveSoundSettings();
        }


        if (PlayerPrefs.HasKey("MusciVolume"))
        {
            ChangeMusicVolume(PlayerPrefs.GetFloat("MusciVolume"));
            if (musicSlider != null)
            {
                musicSlider.value = PlayerPrefs.GetFloat("MusciVolume");
            }
        }
        else
        {
            ChangeMusicVolume(1f);
            SaveMusicSettings();
        }

    }

    public void ChangeMusicVolume(float volume)
    {
        backgroundMusic.volume = volume;
    }

    public void ChangeSoundVolume(float volume)
    {
        audioEffects.volume = volume;
    }

    private void SaveMusicSettings()
    {
        PlayerPrefs.SetFloat("MusciVolume", backgroundMusic.volume);
    }

    private void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat("SoundVolume", audioEffects.volume);
        Debug.Log(audioEffects.volume);
        Debug.Log(PlayerPrefs.GetFloat("SoundVolume"));

    }

    public void SaveSoundAndMusicSettings() {
        SaveMusicSettings();
        SaveSoundSettings();
    }

    public void cancelMusikAndSoundChanges()
    {
        ChangeMusicVolume(PlayerPrefs.GetFloat("MusciVolume"));
        ChangeSoundVolume(PlayerPrefs.GetFloat("SoundVolume"));
        if (musicSlider != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MusciVolume");
        }
        if (soundSlider != null)
        {
            soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        }
    }

    public void editMusicVolumeWithSlider()
    {
        ChangeMusicVolume(musicSlider.value);
    }

    public void editSoundVolumeWithSlider()
    {
        ChangeSoundVolume(soundSlider.value);
    }

    public void PlaySound(playerActions clip)
    {
        if (audioEffects != null)
        {
            switch (clip)
            {
                case playerActions.jump: audioEffects.PlayOneShot(playerJumpSound); break;
                case playerActions.die: audioEffects.PlayOneShot(playerDieSound); break;
                case playerActions.slide: audioEffects.PlayOneShot(playerSlideSound); break;
            }
        }
    }

    public void PlayTestSound() {
        PlaySound(playerActions.jump);
    }
}


