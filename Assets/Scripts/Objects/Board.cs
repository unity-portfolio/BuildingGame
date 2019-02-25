using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private Building[,] buildings = new Building[100,100];
    
    public void AddBuilding(Building building, Vector3 position)
    {
        buildings[(int)position.x, (int)position.z] = Instantiate(building, position, Quaternion.identity);
    }

    public bool CheckForBuilding(Vector3 position)
    {
        return buildings[(int)position.x, (int)position.z] != null;
    }

    public Vector3 CalculateGridPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round(position.x),0.25f, Mathf.Round(position.z));
    }
}
