using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBuilding : MonoBehaviour
{
    [System.Serializable]
    public class GhostPrefab
    {
        public GameObject prefab;
        public Color color = Color.white;
    }

    [SerializeField] private List<GhostPrefab> ghostPrefabs;
    private List<GameObject> currentGhosts = new List<GameObject>();

    public void ShowGhosts(List<Vector3> positions, List<bool> canBuild)
    {
        DestroyCurrentGhosts();

        for (int i = 0; i < positions.Count; i++)
        {
            GameObject prefab = canBuild[i] ? GetGhostPrefab(i) : null;
            GameObject ghost = Instantiate(prefab, positions[i], Quaternion.identity);
            if (ghost != null)
            {
                MeshRenderer renderer = ghost.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material.color = ghostPrefabs[i].color;
                }
                currentGhosts.Add(ghost);
            }
        }
    }

    private GameObject GetGhostPrefab(int index)
    {
        return index < ghostPrefabs.Count ? ghostPrefabs[index].prefab : null;
    }

    private void DestroyCurrentGhosts()
    {
        foreach (GameObject ghost in currentGhosts)
        {
            Destroy(ghost);
        }
        currentGhosts.Clear();
    }
}
