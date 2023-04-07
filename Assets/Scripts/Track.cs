using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public SongData song;
    public AudioSource audioSource;

    public static Track instance;

    private void Start()
    {
        transform.position = Vector3.forward * (song.speed * GameManager.instance.startTime);
        Invoke("StartSong", GameManager.instance.startTime - song.startTime);
    }

    void StartSong()
    {
        audioSource.PlayOneShot(song.song);
        Invoke("SongIsOver", song.song.length);
    }

    void Update()
    {
        transform.position += Vector3.back * song.speed * Time.deltaTime;
    }

    public void SongIsOver()
    {
        GameManager.instance.WinGame();
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < 150; i++)
        {
            float beatLength = 60.0f / (float)song.bpm;
            float beatDist = beatLength * song.speed;

            Gizmos.DrawLine(transform.position + new Vector3(-1, 0, i * beatDist), transform.position + new Vector3(1, 0, i * beatDist));
        }
    }
}
