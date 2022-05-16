using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("GrappleGun Settings")]
    public LayerMask WhatIsGrappleAble;
    public float MaxDistance = 100f;
    public float Spring;
    public float Damper;
    public float Mass;

    [Header("GrappleGun Info")]
    public Transform GunTip, Camera, Player;

    private SpringJoint joint;
    private LineRenderer lr;
    private Vector3 grapplePoint;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartGrapple();
        else if (Input.GetMouseButtonUp(1))
            StopGrapple();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.position, Camera.forward, out hit, MaxDistance, WhatIsGrappleAble))
        {
            lr.positionCount = 2;
            grapplePoint = hit.point;
            joint = Player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(Player.position, grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = Spring;
            joint.damper = Damper;
            joint.massScale = Mass;
        }
    }
    
    private void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, GunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.transform.position, Camera.transform.forward);
    }
}
