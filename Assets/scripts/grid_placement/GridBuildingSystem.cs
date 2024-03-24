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
        Vector3 gridPosition = new Vector3(896f, 12f, 1086f);

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

        

        public void ClearTransform()
        {
            transform = null;
        }
    }

    private void Update()
    {
        
        if (buttonClicked && Input.GetMouseButtonDown(0))
        {
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);

            GridObject gridObject = grid.GetGridObject(x, z);
           
             
                Transform buildTransform = Instantiate(placedObjectTypeSO.prefab, grid.GetWorldPosition(x, z), Quaternion.Euler(0f, -180f, 0f));
                buttonClicked = false;

           
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

