using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
    [Header("GrappleGun Settings")]
    [SerializeField] private LayerMask whatIsGrappleAble;
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float spring;
    [SerializeField] private float damper;
    [SerializeField] private float mass;

    [Header("GrappleGun Info")]
    [SerializeField] private Transform gunTip, cam, player;

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
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance, whatIsGrappleAble))
        {
            lr.positionCount = 2;
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);
            joint.maxDistance = distanceFromPoint * 0.5f;
            joint.minDistance = distanceFromPoint * 0.25f;

            joint.spring = spring;
            joint.damper = damper;
            joint.massScale = mass;
        }
    }
    
    private void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, grapplePoint);
    }

    private void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.transform.position, cam.transform.forward);
    }
}
