using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _threshold = 0.01f; 
    private Transform _target;

    private int wavepointIndex = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _target = WaypointsController.waypoints[0];

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (_target.position - transform.position).normalized;
        transform.Translate(dir *_speed*Time.deltaTime, Space.World);

        
        if (Vector3.Distance(_target.position,transform.position) < _threshold)
        {
            GetNextWayPoint();
        }

    }

    private void GetNextWayPoint()
    {
        if (wavepointIndex < WaypointsController.waypoints.Length - 1)
        {
            wavepointIndex++;
            _target = WaypointsController.waypoints[wavepointIndex];
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
