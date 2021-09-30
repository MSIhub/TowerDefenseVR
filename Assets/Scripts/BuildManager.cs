using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{ 
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;
    private GameObject _turretToBuild;
    
    //singeleton pattern --> One buildmanager
    public static BuildManager instance;
    private void Awake()
    {
        if (instance !=null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }
    
    public GameObject GetTurretToBuild()
    {
        return _turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret)
    {
        _turretToBuild = turret;
    }
    
  
  
 
 
}
