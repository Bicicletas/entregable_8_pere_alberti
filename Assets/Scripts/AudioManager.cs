using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //Variable que guarda un aray de audioClips
    public AudioClip[] aduioClips;
    //Variable que guarda el nombre de las canciones
    public string[] nombreSong;
    //Variable que guarda el audioSource del AudioManager
    private AudioSource AMAudioSource;
    //Variable que guarda la cancion sonando en el momento actual
    private int courrentSong;
    //Variable que guarda el texto
    public TextMeshProUGUI SN;
    //Numeros a piñon
    private int maxSong = 4;
    private int returnSong = 5;
    private int gnoSnruter = -1; 
    //movidas mias
    private bool isPaused;

    void Start()
    {
        isPaused = false;
        AMAudioSource = GetComponent<AudioSource>();
        //Nada mas empieza el juego suena la primera cancion del aray
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }
    private void Update()
    {
        //Se encarga de poner el nombre de la cancion que este sonando
        SN.text = nombreSong[courrentSong];
        //movidas mias
        if(Input.GetKeyDown(KeyCode.Space) && isPaused == false)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isPaused == true)
        {
            Play();
        }
        //mas movidas
        if(AMAudioSource.isPlaying == false && isPaused == false)
        {
            Nextsong();
        }
    }
    //funcion para despausar la cancion
    public void Play()
    {
        AMAudioSource.UnPause();
        isPaused = false;
    }
    //funcion para pausar la cancion
    public void Pause()
    {
        AMAudioSource.Pause();
        isPaused = true;
    }
    //funcion para pasar a la siguiente cancion
    public void Nextsong()
    {
        AMAudioSource.Stop();
        courrentSong++;
        if (courrentSong == returnSong)
        {
            courrentSong = 0;
        }
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }
    //funcion para pasar a la cancion anterior
    public void LastSong()
    {
        AMAudioSource.Stop();
        courrentSong--;
        if (courrentSong == gnoSnruter)
        {
            courrentSong = maxSong;
        }
        AMAudioSource.PlayOneShot(aduioClips[courrentSong]);
    }
    //funcion para pasar a la siguiente cancion de manera random
    public void RandomSong()
    {
        int radomNum = Random.Range(0, returnSong);
        courrentSong = radomNum;
        AMAudioSource.Stop();
        AMAudioSource.PlayOneShot(aduioClips[radomNum]);
    }
}
