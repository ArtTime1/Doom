using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public Material aggroMaterial;   
    private MeshRenderer _meshRenderer;
    public bool isAggro;
    [SerializeField] private float _awarenessRadius = 8f;
    [SerializeField] private Transform _playersTransform;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        var distance = Vector3.Distance(transform.position, _playersTransform.position);

        if (distance < _awarenessRadius)
        {
            isAggro = true;
        }

        if (isAggro)
        {
            _meshRenderer.material = aggroMaterial;
        }

    }

}




