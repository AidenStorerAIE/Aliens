using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPiece : MonoBehaviour
{
    bool triggered;
    private MapManager mapManager;
    [SerializeField] private List<GameObject> states;
    private List<GameObject> possibleStates;

    // Start is called before the first frame update
    void Start()
    {
        mapManager = FindObjectOfType<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdatePiece(GameObject triggeringPiece)
    {
       if (!triggered)
        {
            if (triggeringPiece == null)
            {
                states[0].SetActive(true);
                return;
            }
        }
    }
}
