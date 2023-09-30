using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class CAMURA : MonoBehaviour
{
    private bool rotatable;
    [SerializeField] private Transform roomPos;
    [SerializeField] private GameObject resetButton;
    [SerializeField] private GameObject lastInteract;
    // Start is called before the first frame update
    void Start()
    {
        rotatable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotatable)
        {
            if (Input.mousePosition.x < 100)
            {
                transform.Rotate(0f, -1f, 0f);
            }
            if (Input.mousePosition.x > Screen.width - 100)
            {
                transform.Rotate(0f, 1f, 0f);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<INTERACTABLE>() != null)
                {
                    ChangeCameraPos(hit.collider.gameObject);
                }
                if (hit.collider.gameObject.GetComponent<Key>() != null)
                {
                    hit.collider.gameObject.GetComponent<Key>().Run();
                }
                if (hit.collider.gameObject.GetComponent<Door>() != null)
                {
                    hit.collider.gameObject.GetComponent<Door>().TryDoor();
                }
                if (hit.collider.gameObject.GetComponent<Alien>() != null)
                {
                    hit.collider.gameObject.GetComponent<Alien>().Aliened();
                }
                if (hit.collider.gameObject.GetComponent<Elevator>() != null)
                {
                    hit.collider.gameObject.GetComponent<Elevator>().PlayMusic();
                }

            }
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<Spin>() != null)
                {
                    hit.collider.gameObject.GetComponent<Spin>().Rotato();
                }
            }
        }
    }
    void ChangeCameraPos(GameObject interacted)
    {
        rotatable = false;
        resetButton.SetActive(true);
        lastInteract = interacted.gameObject;
        foreach (GameObject g in lastInteract.GetComponent<INTERACTABLE>().subInteractables)
        {
            g.SetActive(true);
        }
        foreach (GameObject g in lastInteract.GetComponent<INTERACTABLE>().objToDisable)
        {
            g.SetActive(false);
        }
        lastInteract.SetActive(false);
        transform.position = interacted.GetComponent<INTERACTABLE>().cameraPos.position;
        transform.rotation = interacted.GetComponent<INTERACTABLE>().cameraPos.rotation;
    }
    public void ResetCameraPos()
    {
        resetButton.SetActive(false);
        rotatable = true;
        lastInteract.gameObject.SetActive(true);
        foreach (GameObject g in lastInteract.GetComponent<INTERACTABLE>().subInteractables)
        {
            g.SetActive(false);
        }
        foreach (GameObject g in lastInteract.GetComponent<INTERACTABLE>().objToDisable)
        {
            g.SetActive(true);
        }
        lastInteract =null;
        transform.position = roomPos.position;
        transform.rotation = roomPos.rotation;
    }

}
