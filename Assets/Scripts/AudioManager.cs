using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    // Singleton
    public static AudioManager instance; 

    // Serialized
    [SerializeField] private List<Audio> audioList;
    
    // Private
    private Dictionary<string, Audio> audioMap = new Dictionary<string, Audio>();

    // Components
    private AudioSource audioSource;

    void Awake(){
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach(Audio audio in audioList){
            audioMap[audio.name] = audio;
        }
    }

    public void Play(string name){
        if(audioMap.ContainsKey(name)){
            audioSource.PlayOneShot(audioMap[name].clip);
        }
    }

    public void PlayMusic(string name){
        if(audioMap.ContainsKey(name)){
            audioSource.clip = audioMap[name].clip;
            audioSource.Play();
        }
    }

    public void Stop(){
        audioSource.Stop();
    }
}

[System.Serializable]
public class Audio {
    public string name;
    public AudioClip clip;
}