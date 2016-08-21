using UnityEngine;
using System.Collections;

public class NoteBox : MonoBehaviour
{
    AudioSource player;
    public AudioClip[] clips = new AudioClip[16];

    public AudioClip[] bar1 = new AudioClip[16];
    public AudioClip[] bar2 = new AudioClip[16];
    public AudioClip[] bar3 = new AudioClip[16];
    public AudioClip[] bar4 = new AudioClip[16];
    public AudioClip[] bar5 = new AudioClip[16];
    public AudioClip[] bar6 = new AudioClip[16];
    public AudioClip[] bar7 = new AudioClip[16];
    public AudioClip[] bar8 = new AudioClip[16];

    int bar1clips = 0;
    int bar2clips = 0;
    int bar3clips = 0;
    int bar4clips = 0;
    int bar5clips = 0;
    int bar6clips = 0;
    int bar7clips = 0;
    int bar8clips = 0;

    int maxClips = 2;

    void Start()
    {
        player = GetComponent<AudioSource>();
        AddBar();
        PlayNextBar();
        StartCoroutine(AddBarRepeater());
    }

    IEnumerator AddBarRepeater()
    {
        yield return new WaitForSeconds(4);
        if (bar1clips >= maxClips && bar2clips >= maxClips && bar3clips >= maxClips && bar4clips >= maxClips && bar5clips >= maxClips && bar6clips >= maxClips && bar7clips >= maxClips && bar8clips >= maxClips)
        {
            StopCoroutine(AddBarRepeater());
        }
        else
        {
            AddBar();
            StartCoroutine(AddBarRepeater());
        }
    }

    public void AddBar()
    {
        int randBar = Random.Range(0, 8);
        int randNote = Random.Range(0, 16);
        switch (randBar)
        {
            case 0:
                bar1[randNote] = clips[randNote];
                bar1clips++;
                break;
            case 1:
                bar2[randNote] = clips[randNote];
                bar2clips++;
                break;
            case 2:
                bar3[randNote] = clips[randNote];
                bar3clips++;
                break;
            case 3:
                bar4[randNote] = clips[randNote];
                bar4clips++;
                break;
            case 4:
                bar5[randNote] = clips[randNote];
                bar5clips++;
                break;
            case 5:
                bar6[randNote] = clips[randNote];
                bar6clips++;
                break;
            case 6:
                bar7[randNote] = clips[randNote];
                bar7clips++;
                break;
            case 7:
                bar8[randNote] = clips[randNote];
                bar8clips++;
                break;
        }
    }

    public int currentBar = 0;
    public void PlayNextBar()
    {
        currentBar++;
        if (currentBar > 7)
        {
            currentBar = 0;
        }
        switch (currentBar)
        {
            case 0:
                StartCoroutine(PlayBar(bar1));
                break;
            case 1:
                StartCoroutine(PlayBar(bar2));
                break;
            case 2:
                StartCoroutine(PlayBar(bar3));
                break;
            case 3:
                StartCoroutine(PlayBar(bar4));
                break;
            case 4:
                StartCoroutine(PlayBar(bar5));
                break;
            case 5:
                StartCoroutine(PlayBar(bar6));
                break;
            case 6:
                StartCoroutine(PlayBar(bar7));
                break;
            case 7:
                StartCoroutine(PlayBar(bar8));
                break;
        }
    }

    IEnumerator PlayBar(AudioClip[] bar)
    {
        for (int i = 0; i < bar.Length; i++)
        {
            player.PlayOneShot(bar[i]);
        }
        yield return new WaitForSeconds(0.5f);
        PlayNextBar();
    }
}
