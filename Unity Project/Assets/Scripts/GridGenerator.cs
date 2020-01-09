using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] GameObject grid;

    private bool gridExists;
    public int gridGenerate = 15;

    private const float GRID_SPACE_HEIGHT = 9.6f;

    private List<Transform> gridTransform;

    public float zToLerp = -11.4f;
    public float gridSpeed = 2f;
    public float maxDistanceofCamera = 2f;

    public int currentGridHeader = 0;
    public int lastGridElement = 0;

    public Color startColour, endColour;

    private void Awake()
    {
        gridTransform = new List<Transform>();

        gridExists = grid != null;

        if (gridExists)
        {
            GameObject previousGo = grid;
            for ( int i = 0; i < gridGenerate; i++)
            {
                GameObject go = Instantiate(grid);
                go.transform.position = previousGo.transform.position;
                go.transform.position = new Vector3(previousGo.transform.position.x, previousGo.transform.position.y, previousGo.transform.position.z);

                MeshRenderer[] rs = go.GetComponentsInChildren<MeshRenderer>();
                for (int j = 0; j > rs.Length; j++)
                {
                    rs[j].material.color = endColour;
                }

                gridTransform.Add(go.transform);

                previousGo = go;
            }
        }
    }

    private void Update()
    {
        for (int i = 0; i < gridTransform.Count; i++)
        {
            Transform gridT = gridTransform[i];
            gridT.position = Vector3.MoveTowards(gridT.position, new Vector3(gridT.position.x, gridT.position.y, zToLerp - (GRID_SPACE_HEIGHT * i)), Time.deltaTime * gridSpeed);

            float dist = Vector3.Distance(Camera.main.transform.position, gridTransform[i].position);


            MeshRenderer[] rs = gridTransform[i].GetComponentsInChildren<MeshRenderer>();
            for (int j = 0; j < rs.Length; j++)
            {
                rs[j].material.color = Color.Lerp(rs[j].material.color, endColour, Time.deltaTime * (dist / maxDistanceofCamera) / 1000);
            }

            Vector3 toTarget = (Camera.main.transform.position - gridTransform[i].position).normalized;

            if (Vector3.Dot(toTarget, transform.forward) > 0)
            {
                Transform t = grid.transform;
                gridTransform[i].position = new Vector3(t.position.x, t.position.y, t.position.z - GRID_SPACE_HEIGHT);
                currentGridHeader++;

                for (int j = 0; j < rs.Length; j++)
                {
                    rs[j].material.color = startColour;
                }

                if (currentGridHeader > gridTransform.Count)
                {
                    currentGridHeader = 0;
                }
            }

        }
    }
}
