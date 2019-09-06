using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour {

    public static SoundManger Instance;

    AudioSource _audio;

    [SerializeField] AudioClip _soundFire;

    private void Awake () {
        if (Instance != null && Instance != this) {
            Destroy (gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad (gameObject);
    }
    // Start is called before the first frame update
    void Start () {
        _audio = GetComponent<AudioSource> ();
    }

    public void playSoundFire () {
        _audio.PlayOneShot (_soundFire);
    }
}