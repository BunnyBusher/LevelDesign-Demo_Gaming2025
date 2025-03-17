using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGeneratorMono : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] public Vector2Int m_gridSize;
    [Space]
    [SerializeField] public float m_offset;
    public GameObject[] m_gameObjects;
    private List<GameObject> _gameObjectList = new();
    private Transform _transform;
    public Vector3 m_centerOfGrid;
    private Vector2 _gridMaxSize;

    private void Awake()
    {
        _transform = transform;
        m_gameObjects = new GameObject[m_gridSize.x * m_gridSize.y];
        CreateGrid();
        //ColorGridOutline();
        //ColorGridDiagonalsBlackWhite();

        _gridMaxSize = new Vector2((m_gridSize.x * m_offset) - m_offset, (m_gridSize.y * m_offset) - m_offset);
        m_centerOfGrid = _gridMaxSize * 0.5f;
    }

    private void CheckIfMultiple()
    {
        if ((m_gridSize.y != 0 && m_gridSize.x % m_gridSize.y == 0) ||
                (m_gridSize.x != 0 && m_gridSize.y % m_gridSize.x == 0))
        {
            ColorGridDiagonalsIfSException();
        }
    }

    private void ColorGridDiagonalsBlackWhite()
    {
        if (m_gridSize.x % 2 == 0 && m_gridSize.x == m_gridSize.y)
        {
            ColorGridDiagonalsIfSException();
        }
        else if ((m_gridSize.y != 0 && m_gridSize.x % m_gridSize.y == 0) ||
                (m_gridSize.x != 0 && m_gridSize.y % m_gridSize.x == 0))
        {
            ColorGridDiagonalsIfSException();
        }
        else
        {
            ColorGridBlackAndWhite();
        }
    }

    private void ColorGridDiagonalsIfSException()
    {
        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            if ((i / m_gridSize.x) % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.black;
                }
                else if (i % 2 == 1)
                {
                    m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                }
                else if (i % 2 == 1)
                {
                    m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.black;
                }
            }
        }
    }

    private void ColorGridBlackAndWhite()
    {

        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            if (i % 2 == 0)
            {
                m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.white;
            }
            else if (i % 2 == 1)
            {
                m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.black;
            }
        }

    }

    private void ColorGridOutline()
    {
        int index = m_gameObjects.Length - 1;
        for (int i = 0; i < m_gameObjects.Length; i++)
        {
            if (i % m_gridSize.x == 0)
            {
                m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
            if (i % m_gridSize.x == (m_gridSize.x - 1))
            {
                m_gameObjects[i].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
        }
        for (int a = 0; a < m_gridSize.x; a++)
        {
            m_gameObjects[a].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            int b = index - a;
            m_gameObjects[b].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        }
    }

    private void CreateGrid()
    {
        uint index = 0;

        for (int x = 0; x < m_gridSize.x; x++)
        {

            for (int y = 0; y < m_gridSize.y; y++)
            {
                var current = Instantiate(_prefabToSpawn, new Vector3(x * m_offset, y * m_offset, 0), Quaternion.identity, _transform);
                m_gameObjects[index] = current;
                _gameObjectList.Add(current);
                index++;
            }
        }
    }
}