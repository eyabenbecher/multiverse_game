using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GridBuildingSystem;

public class Gridforbase : MonoBehaviour
{
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeList;
    [SerializeField] private PlacedObjectTypeSO placedObjectTypeSO;
    private PlacedObjectTypeSO.Dir dir = PlacedObjectTypeSO.Dir.Down;
    private GridXZ<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10;
        int gridHeight = 10;
        float cellSize = 10f;
        Vector3 gridPosition = new Vector3(-50.8699989f, 2335.58008f, -70f);
        grid = new GridXZ<GridObject>(gridWidth, gridHeight , cellSize , gridPosition, (GridXZ<GridObject> g , int x, int z)=> new GridObject(g, x, z));
    }
    public class GridObject
    {
        private GridXZ<GridObject> grid;
        private int x;
        private int z;
        private Transform transform;
        public GridObject(GridXZ<GridObject> grid, int x , int z)
        {
            this.grid = grid;
            this.x = x;
            this.z = z;
        }
        public void SetTransform( Transform transform)
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
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXZ(Mouse3D.GetMouseWorldPosition(), out int x, out int z);
           List<Vector2Int> gridPositionList = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, z), PlacedObjectTypeSO.Dir.Down);
            GridObject gridObject = grid.GetGridObject(x, z);
            if (gridObject.CanBuild())
            {
               Transform buildTransform = Instantiate(placedObjectTypeSO.prefab, grid.GetWorldPosition(x, z), Quaternion.Euler(0,placedObjectTypeSO.GetRotationAngle(dir),0));
                gridObject.SetTransform(buildTransform);
            }
            else { Debug.Log("cannot build here"); }
           
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            dir = PlacedObjectTypeSO.GetNextDir(dir);
            Debug.Log("" + dir);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { placedObjectTypeSO = placedObjectTypeList[0];}
        if (Input.GetKeyDown(KeyCode.Alpha2)) { placedObjectTypeSO = placedObjectTypeList[1]; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { placedObjectTypeSO = placedObjectTypeList[2]; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { placedObjectTypeSO = placedObjectTypeList[3]; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { placedObjectTypeSO = placedObjectTypeList[4]; }
    }
}
