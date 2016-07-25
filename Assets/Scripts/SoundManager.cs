using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
    private AudioSource soundSource;
    public AudioClip[] sounds;
    void Awake()
    {
        if (!instance)
            instance = this;
    }
	// Use this for initialization
	void Start () {
        soundSource = GetComponent<AudioSource>();
        
	}
    public void Player(int index)
    {
        soundSource.PlayOneShot(sounds[index]);
    }
	// Update is called once per frame
	void Update () {
	
	}
}
