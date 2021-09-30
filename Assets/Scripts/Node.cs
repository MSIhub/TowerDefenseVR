using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Node : MonoBehaviour
{
    [SerializeField] private Material hoverMaterial;
    [SerializeField] private XRSimpleInteractable _nodeXRInteractor;
    [SerializeField] private Vector3 _positionOffsetTurret;
    private Renderer _rend;
    private Material _initNodeMaterial;
    
    [Header("Optional")]
    public GameObject turret;
    private BuildManager _buildManager;

    private void Awake()
    {
        _nodeXRInteractor.hoverEntered.AddListener(NodeHoverEnter);
        _nodeXRInteractor.hoverExited.AddListener(NodeHoverExit);
        
        _nodeXRInteractor.selectEntered.AddListener(NodeSelectEnter);
        _nodeXRInteractor.selectExited.AddListener(NodeSelectExit);
    }
    
    
    private void Start()
    {
        _rend = GetComponent<MeshRenderer>();
        _initNodeMaterial = _rend.material;
        _buildManager = BuildManager.instance;
        
    }
    
    private void NodeHoverEnter(HoverEnterEventArgs arg0)
    {
        if (!_buildManager.CanBuild) return;
        _rend.material = hoverMaterial;
    }
    
    private void NodeHoverExit(HoverExitEventArgs arg0)
    {
        _rend.material = _initNodeMaterial;
    }
    
    private void NodeSelectEnter(SelectEnterEventArgs arg0)
    {
        if (!_buildManager.CanBuild) return;
        
        if (turret!=null)
        {
            Debug.Log("Can't Build here");
            return;
        }
        
        //Build a turret
        _buildManager.BuildTurretOn(this);
    }
    
    private void NodeSelectExit(SelectExitEventArgs arg0)
    {
        
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + _positionOffsetTurret;
    }

    
}
