using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float _range = 0.25f;
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private Transform _rotationAnchor;
    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private float _fireRate = 1f;
    private float _fireCountDown = 0f;
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget),0f,0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;
        Vector3 dir = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 newRot = Quaternion.Slerp(_rotationAnchor.rotation, lookRotation, _turnSpeed * Time.deltaTime).eulerAngles;
        _rotationAnchor.rotation = Quaternion.Euler(0f, newRot.y, 0f);

        if (_fireCountDown <=0f)
        {
            Shoot();
            _fireCountDown = 1f / _fireRate;
        }

        _fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {       
        Debug.Log("Shoot");
    }

    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (var enemy in enemies)
        {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
