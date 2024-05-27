using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("=== AUDIO SRC ===")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;

    [Header("=== AUDIO SFX ===")]
    public AudioClip background;
    public AudioClip Death;
    public AudioClip Explosion;
    public AudioClip Shoot;

    public void DeathSound( ) {
        SFX.clip = Death;
        SFX.Play();
    }
    public void ExplosionSound() {
        SFX.clip = Explosion;
        SFX.Play();
    }
    public void ShootSound() {
        SFX.clip = Shoot;
        SFX.Play();
    }
}
