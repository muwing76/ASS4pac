using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIntroSwitcher : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip IntroBGM, Bgm;
    // Start is called before the first frame update
    void Start()
    {
        if (!musicSource || !IntroBGM || !Bgm) return;
        musicSource.loop = false; musicSource.clip = IntroBGM; musicSource.Play();
        Invoke(nameof(SwitchToNormal), Mathf.Min(3f, IntroBGM.length));
    }

    void SwitchToNormal()
    {
        musicSource.loop = true; musicSource.clip = Bgm; musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
