using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyValue;
    public KeyPad keyPad;
    // Start is called before the first frame update
    void Start()
    {
        keyPad = FindObjectOfType<KeyPad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Run()
    {
        keyPad.KeyInput(keyValue);
    }
}
