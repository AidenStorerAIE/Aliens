using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    [SerializeField] private int row;
    [SerializeField] private int column;
    [SerializeField] private GameObject middle;
    [SerializeField] public List<Vector3> objectPos;
    [SerializeField] public List<GameObject> objects;
    void Start()
    {
        CreateRoom();
    }
    void CreateRoom()
    {
        int initialRow = 0;
        int initialColumn = 0;
        for (int i = 0; i < column; i++)
        {
            for (int ii = 0; ii < row; ii++)
            {
                GameObject piece = Instantiate(middle, new Vector3(initialRow * 10, 0, initialColumn * 10), Quaternion.identity, this.transform);
                objectPos.Add(piece.transform.position);
                objects.Add(piece);
                initialRow++;
            }
            initialRow = 0;
            initialColumn++;
        }
    }
}
