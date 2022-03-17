using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] aduioClips;
    public string[] nombreSong;
    private AudioSource AMAudioSource;
    private int courrentSong;

    // Start is called before the first frame update
    void Start()
    {
        AMAudioSource = GetComponent<AudioSource>();
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }

    public void Play()
    {
        AMAudioSource.UnPause();
    }
    public void Pause()
    {
        AMAudioSource.Pause();
    }
    public void Nextsong()
    {
        AMAudioSource.Stop();
        courrentSong++;
        if (courrentSong == 5)
        {
            courrentSong = 0;
        }
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }
    public void LastSong()
    {
        AMAudioSource.Stop();
        courrentSong--;
        if (courrentSong == -1)
        {
            courrentSong = 4;
        }
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }
    public void RandomSong()
    {
        int radomNum = Random.Range(0, 5);
        courrentSong = radomNum;
        AMAudioSource.Stop();
        AMAudioSource.PlayOneShot(aduioClips[radomNum]);
    }



}
