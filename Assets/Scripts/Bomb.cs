using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bombTimer = 3f;
    [SerializeField] private float timeOfExplosion = 0.5f;
    [SerializeField] private GameObject explosionGO;
    private SpriteRenderer _renderer;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Invoke("Explosion", bombTimer);
        ChangeZPositionOnScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explosion()
    {
        _renderer.enabled = false;
        explosionGO.SetActive(true);
        Invoke("DestroyGO", timeOfExplosion);
    }

    void DestroyGO()
    {
        Destroy(gameObject);
    }

    void ChangeZPositionOnScene()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
