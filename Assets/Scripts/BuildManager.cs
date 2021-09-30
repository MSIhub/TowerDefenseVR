using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{ 
    public GameObject standardTurretPrefab;
    public GameObject missileTurretPrefab;
    public GameObject laserTurretPrefab;
    private TurretBlueprint _turretToBuild;
    
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

    public bool CanBuild => _turretToBuild != null;

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < _turretToBuild.cost)
        {
            Debug.Log("Not enough money");
        }

        PlayerStats.Money -= _turretToBuild.cost;
        GameObject turret = (GameObject) Instantiate(_turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        
        Debug.Log("Turret built! Money Left: "+ PlayerStats.Money.ToString());
    }
  
  
 
 
}
