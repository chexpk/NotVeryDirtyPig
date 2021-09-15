using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombEmitter : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;

    private Transform _transform;

    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutBombOnCurrentPosition()
    {
        var go = Instantiate(bombPrefab, _transform.position, Quaternion.identity);
    }
}
