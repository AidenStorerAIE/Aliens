using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] List<AudioSource> sources;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayMusic()

    {
        foreach (AudioSource source in sources)
        {
            source.Play();
            animator.SetTrigger("Elevator");
        }
    }
}
