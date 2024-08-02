using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("=== VOLUME SETTINGS ===")]
    [Range(0f, 1f)] [HideInInspector] public float MusicVolume;
    [Range(0f, 1f)] [HideInInspector] public float SFXVolume;

    [Header("=== AUDIO SRC ===")]
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    [Header("=== AUDIO MUSIC ===")]

    public AudioClip background;

    [Header("=== AUDIO SFX ===")]
    public AudioClip Death;
    public AudioClip Explosion;
    public AudioClip Shoot;
    public AudioClip Damage;


    public static AudioManager Instance {get; private set;}
    void Awake()
    {
        if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
    }
    void Start() {
        SFXVolume = 0.35f;
        MusicVolume = 0.06f;
        PlayBackgroundSound();
    }

    public void DeathSound( ) {
        if(GameManager.Instance.isGameOver) {
            Music.Stop();
            SFX.Stop(); 
            SFX.PlayOneShot(Death, SFXVolume);
        }
    }
    public void ExplosionSound() {
        SFX.PlayOneShot(Explosion, SFXVolume);
    }
    public void ShootSound() {
        SFX.PlayOneShot(Shoot, SFXVolume);
    }
    public void DamageSound() {
        SFX.PlayOneShot(Damage, SFXVolume);
    }
    public void SetMusicVolume(float volume) {
        Music.volume = volume;
        MusicVolume = volume;
    }
    public void SetSFXVolume(float volume) {
        SFX.volume = volume;
        SFXVolume = volume;;
    }
    public void PlayBackgroundSound() {
        Music.clip = background;
        Music.loop = true; 
        Music.volume = MusicVolume;
        Music.Play();
    }
}
