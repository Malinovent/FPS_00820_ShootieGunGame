using System.Collections.Generic;
using UnityEngine;

public class Pistol : WeaponBase
{
    Camera mainCamera;

    private List<Vector3> hitPoints = new List<Vector3>();

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public override void OnFire()
    {
        //Debug.Log("Pistol fired!");
        /*if(Physics.Raycast(transform.position, transform.forward))
        {
            Debug.Log("Hit something!");
        }*/

        //Vector3 originPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Ray ray = new Ray(originPosition, transform.forward);

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitObject))
        {
            Debug.Log($"Hit Object: {hitObject.collider.name}");
            hitPoints.Add(hitObject.point);
        }
    }

    public override void OnReload()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying)
            return;

        Gizmos.color = Color.red;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitObject))
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(hitObject.point, 0.25f);
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, hitObject.point);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 50);
        }

        foreach(Vector3 point in hitPoints)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(point, 0.2f);
        }
        
    }
}