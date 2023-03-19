using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject audioObj;
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider, SFXSlider, musicSlider;
    private static AudioManager _instance;
    [SerializeField] float multiplier;

    public static AudioManager Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        SetMasterAudio(PlayerPrefs.GetFloat("Master"));
        SetSFXAudio(PlayerPrefs.GetFloat("SFX"));
        SetMusicAudio(PlayerPrefs.GetFloat("Music"));
    }

    public void LoadAudio()
    {
        masterSlider.value = PlayerPrefs.GetFloat("Master");
        SFXSlider.value = PlayerPrefs.GetFloat("SFX");
        musicSlider.value = PlayerPrefs.GetFloat("Music");
    }

    private void Update()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public void SpawnAudio(AudioClip clip, Vector3 pos)
    {
        GameObject audio = Instantiate(audioObj, pos, Quaternion.identity);
        AudioSource source = audio.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(audio, clip.length);
    }

    public void SpawnAudio(AudioClip clip, Transform parent)
    {
        GameObject audio = Instantiate(audioObj, parent);
        audio.transform.parent = parent;
        AudioSource source = audio.GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(audio, clip.length);
    }

    public void SetMasterAudio(float amt)
    {
        mixer.SetFloat("Master", Mathf.Log10(amt) * multiplier);
    }

    public void SetSFXAudio(float amt)
    {
        mixer.SetFloat("SFX", Mathf.Log10(amt) * multiplier);
    }

    public void SetMusicAudio(float amt)
    {
        mixer.SetFloat("Music", Mathf.Log10(amt) * multiplier);
    }

    public void SaveAudio()
    {
        PlayerPrefs.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("SFX", SFXSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
    }
}
