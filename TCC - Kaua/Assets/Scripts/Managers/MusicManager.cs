using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioSource AudioSource;
    public AudioClip[] Musics;
    
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "TitleScreen":

                AudioSource.loop = true;
                PlayMusic(Musics[0]);

            break;

            case "Stage1":

                AudioSource.loop = true;
                PlayMusic(Musics[1]);

            break;

            case "GameOver":

                AudioSource.loop = false;
                PlayMusic(Musics[2]);

            break;
        }
    }
    void PlayMusic(AudioClip clip)
    {
        if (AudioSource.clip == clip) return;
        StopMusic();
        AudioSource.clip = clip;
        AudioSource.Play();
    }

    void StopMusic()
    {
        AudioSource.Stop();
    }
}
