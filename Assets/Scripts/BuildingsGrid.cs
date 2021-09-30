using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 15);

    private ConstructionBuildings[,] _grid;
    private ConstructionBuildings _buildingInstallation;
    private Camera _mainCamera;

    private void Awake()
    {
        _grid = new ConstructionBuildings[GridSize.x, GridSize.y];

        _mainCamera = Camera.main;
    }
    public void StartPlacingBuilding(ConstructionBuildings buildingPrefab)
    {
        _buildingInstallation = Instantiate(buildingPrefab);
    }
    private void Update()
    {
        if (_buildingInstallation != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0 || x > GridSize.x - _buildingInstallation.Size.x)
                {
                    available = false;
                }                    

                if (y < 0 || y > GridSize.y - _buildingInstallation.Size.y)
                {
                    available = false;
                }                    

                if (available && IsPlaceTaken(x, y))
                {
                    available = false;
                }

                _buildingInstallation.transform.position = new Vector3(x, 0, y);
                _buildingInstallation.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceBuildingInstallatio(x, y);
                }
            }
        }
    }
    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < _buildingInstallation.Size.x; x++)
        {
            for (int y = 0; y < _buildingInstallation.Size.y; y++)
            {
                if (_grid[placeX + x, placeY + y] != null) return true;
            }
        }
        return false;
    }
    private void PlaceBuildingInstallatio(int placeX, int placeY)
    {
        for (int x = 0; x < _buildingInstallation.Size.x; x++)
        {
            for (int y = 0; y < _buildingInstallation.Size.y; y++)
            {
                _grid[placeX + x, placeY + y] = _buildingInstallation;
            }
        }
        _buildingInstallation.SetNormal();
        _buildingInstallation = null;
    }
}
