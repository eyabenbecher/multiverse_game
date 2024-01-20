using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeList;
    private PlacedObjectTypeSO placedObjectTypeSO;
    private GridXZ<GridObject> grid;
    private bool buttonClicked = false;

    private void Awake()
    {
        int gridWidth = 50;
        int gridHeight = 20;
        float cellSize = 10f;

        // Set the desired position for the grid
        Vector3 gridPosition = new Vector3(633.667664f, 34f, 1002f);

        grid = new GridXZ<GridObject>(gridWidth, gridHeight, cellSize, gridPosition, (GridXZ<GridObject> g, int x, int z) => new GridObject(g, x, z));
        placedObjectTypeSO = placedObjectTypeList[0];
    }


    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;

        public GridObject(GridXZ<GridObject> grid, int x, int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
        }

        public bool CanBuild()
        {
            return transform == null;
        }

        public void ClearTransform()
        {
            transform = null;
        }
    }

    private void Update()
    {
        // Check if a button has been clicked
        if (buttonClicked && Input.GetMouseButtonDown(0))
        {
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);

            GridObject gridObject = grid.GetGridObject(x, z);
            if (gridObject.CanBuild())
            {
                // Instantiate the prefab and rotate it by -180 degrees around the y-axis
                Transform buildTransform = Instantiate(placedObjectTypeSO.prefab, grid.GetWorldPosition(x, z), Quaternion.Euler(0f, -180f, 0f));

                // Set the transform in the grid object
                gridObject.SetTransform(buildTransform);

                // Reset the buttonClicked flag
                buttonClicked = false;

            }
            else
            {
                Debug.Log("Cannot build here");
            }
        }
    }

    public void OnButton1Click()
    {
        placedObjectTypeSO = placedObjectTypeList[0];
        buttonClicked = true;
    }

    public void OnButton2Click()
    {
        placedObjectTypeSO = placedObjectTypeList[1];
        buttonClicked = true;
    }

    public void OnButton3Click()
    {
        placedObjectTypeSO = placedObjectTypeList[2];
        buttonClicked = true;
    }
}

