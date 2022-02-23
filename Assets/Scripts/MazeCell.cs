using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    public IntVector2 coordinates;

    private MazeCelllEdge[] edges = new MazeCelllEdge[MazeDirections.Count];

    private int initializedEdgeCount;

    public bool IsFullyInitialized 
    {
        get
        {
            return initializedEdgeCount == MazeDirections.Count;
        }
    }

    public MazeCelllEdge GetEdge(MazeDirection direction)
    {
        return edges[(int)direction];
    }

    public void SetEdge(MazeDirection direction, MazeCelllEdge edge)
    {
        edges[(int)direction] = edge;
        initializedEdgeCount += 1;
    }

    public MazeDirection RandomUninitializedDirection 
    {
        get
        {
            int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
            for(int i = 0; i < MazeDirections.Count; i++)
            {
                if(edges[i] == null)
                {
                    if(skips == 0)
                    {
                        return (MazeDirection)i;
                    }

                    skips -= 1;
                }
            }
            throw new System.InvalidOperationException("MazeCell has no uninitialized direction left.");
        }
    }

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
