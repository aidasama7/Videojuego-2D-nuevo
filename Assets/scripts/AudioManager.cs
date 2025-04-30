using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip BandaSonora;
    public AudioClip fxButton;
    public AudioClip fxCoin;
    public AudioClip fxDead;
    public AudioClip fxFire;

    AudioSource _audioSource;


    public static AudioManager Instance;


    void Awake(){

        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
        }else{
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
        _audioSource.clip = BandaSonora;
        _audioSource.loop = true;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //método para hacer sonar clips de audio
    public void SonarClipUnaVez(AudioClip ac){
            _audioSource.PlayOneShot(ac);
    }

}
