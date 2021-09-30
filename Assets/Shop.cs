using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileTurret;
    
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        _buildManager.SelectTurretToBuild(standardTurret);
    }
    
    public void SelectMissileTurret()
    {
        Debug.Log("Missle Turret Selected");
        _buildManager.SelectTurretToBuild(missileTurret);
    }
    
}
