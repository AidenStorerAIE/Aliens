using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    public Text text;
    private bool success;
    private float startTime;
    private bool check;
    public GameObject door;
    private AudioSource audioSource;
    [SerializeField] private List<AudioClip> beeps;
    [SerializeField] private AudioClip fail;
    [SerializeField] private AudioClip successSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        check = true;
        text.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(text.text == "1411")
        {
            text.text = "Success";
            audioSource.clip = successSound;
            audioSource.Play();
            success = true;
            if (door != null)
            {
                door.GetComponent<Door>().locked = false;
            }
            return;
        }
        if (text.text.Length >= 4 && !success && check)
        {
            startTime = Time.time;
            audioSource.clip = fail;
            audioSource.Play();
            text.text = "Fail";
            text.color = Color.red;
            check = false;
            return;
        }
        if (startTime + 2 < Time.time && !check)
        {
                text.text = "";
            text.color = Color.green;
            check = true;
        }
    }
    public void KeyInput(int keyNum)
    {
        if (!success && check == true)
        {
            audioSource.clip = beeps[Random.Range(0, beeps.Count)];
            audioSource.Play();
            text.text = text.text + keyNum.ToString();
            return;
        }
    }

}
