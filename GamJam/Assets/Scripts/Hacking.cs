using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hacking : MonoBehaviour
{
    public Slider hackingSlider;
    public float hackValue;
    private string text;
    private bool hacked;
    public Text texty;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        hackValue = 0;
        hacked = false;
        text = "Hacking...";
    }

    // Update is called once per frame
    void Update()
    {
        texty.text = text;
        hackingSlider.value = hackValue;
        if (hackValue > 0 && !hacked)
        {
            hackValue -= .01f;
        }
        if (Input.anyKeyDown)
        {
            hackValue += 1;
        }
        if (hackValue >= hackingSlider.maxValue)
        {
            hacked = true;
            if (door != null)
            {
                door.GetComponent<Door>().locked = false;
            }
            text = "Hacked";
        }
    }
}
