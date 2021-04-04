using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] AudioSource asource;
    public float sound;
    // Start is called before the first frame update
    void Start()
    {
        
        DontDestroyOnLoad(this);
        if (!asource.isPlaying)
        {
            asource.Play();
        }
        
    }
    private void Update()
    {
        asource.volume = sound;
    }
    public void MusicSlider(float rate)
    {
        sound = rate;
    }
}
