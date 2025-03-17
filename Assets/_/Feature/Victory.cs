using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private GridGeneratorMono _gridScript;
    [SerializeField] private float _offsetVictoryPosition;

    [Range(0f,81f)]
    [SerializeField] private int _victoryIndex;
    [SerializeField] private Transform _victoryPrefab;
    private Transform _victoryTransform;
    



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_victoryIndex = 0;
        InitiateVcitoryPosition();
    }

    private void InitiateVcitoryPosition()
    {
        _victoryTransform = Instantiate(_victoryPrefab, _gridScript.m_gameObjects[_victoryIndex].transform.position, Quaternion.identity);
        AddPlayerOffset();
    }

    private void AddPlayerOffset()
    {
        _victoryTransform.position += new Vector3(0, 0, -_offsetVictoryPosition);
    }

}
