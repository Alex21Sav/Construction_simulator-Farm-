using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionBuildings : MonoBehaviour
{  
    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;

    public void SetTransparent(bool available)
    {
        if (available)
        {
            MainRenderer.material.color = Color.blue;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }
    public void SetNormal()
    {
        MainRenderer.material.color = Color.white;
    }
    private void OnDrawGizmos()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
            {
                Gizmos.color = new Color(0.50f, 0.50f, 1f, 0.60f);
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 0.1f, 1));
            }
        }
    }   
}
