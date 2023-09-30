using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationalCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.mousePosition.x < 100)
            {
                transform.Rotate(0f, -.1f, 0f);
            }
            if (Input.mousePosition.x > Screen.width - 100)
            {
                transform.Rotate(0f, .1f, 0f);
            }
    }



}
