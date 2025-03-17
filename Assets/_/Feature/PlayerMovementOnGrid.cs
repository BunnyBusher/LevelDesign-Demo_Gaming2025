using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerOnGrid : MonoBehaviour
{
    [SerializeField] private GridGeneratorMono _gridScript;
    [SerializeField] private Transform _playerPrefab;
    [Space]
    [SerializeField] private float _offsetPlayerPosition = 1f;

    private Transform _playerTransform;
    private int _playerIndex;


    private void Start()
    {
        _playerIndex = 0;
        InitiatePlayerPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int newIndex = _playerIndex + _gridScript.m_gridSize.y;
            if (newIndex < _gridScript.m_gameObjects.Length)
            {
                _playerIndex = newIndex;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
            else
            {
                _playerIndex = (newIndex % _gridScript.m_gridSize.y);
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int newIndex = _playerIndex - _gridScript.m_gridSize.y;
            if (newIndex >= 0)
            {
                _playerIndex = newIndex;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
            else
            {
                _playerIndex = newIndex + _gridScript.m_gameObjects.Length;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int newIndex = _playerIndex + 1;
            if (newIndex % _gridScript.m_gridSize.y != 0)
            {
                _playerIndex = newIndex;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();

            }
            else
            {
                _playerIndex = newIndex - _gridScript.m_gridSize.y;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int newIndex = _playerIndex - 1;
            if ((newIndex + 1) % _gridScript.m_gridSize.y != 0)
            {
                _playerIndex = newIndex;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();

            }
            else
            {
                _playerIndex = newIndex + _gridScript.m_gridSize.y;
                _playerTransform.position = _gridScript.m_gameObjects[_playerIndex].transform.position;
                AddPlayerOffset();
            }
        }

    }
    private void InitiatePlayerPosition()
    {
        _playerTransform = Instantiate(_playerPrefab, _gridScript.m_gameObjects[_playerIndex].transform.position, Quaternion.identity);
        AddPlayerOffset();
    }

    private void AddPlayerOffset()
    {
        _playerTransform.position += new Vector3(0, 0, -_offsetPlayerPosition);
    }
}