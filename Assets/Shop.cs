using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.standardTurretPrefab);
    }
    
    public void PurchaseMissileTurret()
    {
        Debug.Log("Missle Turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.missileTurretPrefab);
    }
    
    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser Turret Selected");
        _buildManager.SetTurretToBuild(_buildManager.laserTurretPrefab);
    }
}
