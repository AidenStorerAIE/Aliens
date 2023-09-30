using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked;
    public ParticleSystem lockedP;
    public string sceneToLoad;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clipList;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TryDoor()
    {
        if (locked)
        {
            lockedP.Play();
            audioSource.clip = clipList[Random.Range(0, clipList.Count)];
            audioSource.Play();
            return;
        }
        else if (!locked)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
