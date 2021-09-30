using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 10f;
    //[SerializeField] private GameObject _impactEffect;
    private Transform _target;
    
    public void SetTarget(Transform target)
    {
        _target = target;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (_target.position - transform.position);
        float distThisFrame = _bulletSpeed * Time.deltaTime;

        if (dir.magnitude  <= distThisFrame)
        {
            HitTarget();
            return;
        }
        
        transform.Translate(dir.normalized * distThisFrame, Space.World);
    }

    private void HitTarget()
    {
        //GameObject effectInstance = Instantiate(_impactEffect, transform.position, transform.rotation);
        //Destroy(effectInstance, 2f);
        
        Destroy(_target.gameObject);
        Destroy(gameObject);
    }
}
