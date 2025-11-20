using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserEmitter : MonoBehaviour
{
    [Header("Laser Settings")]
    public Transform laserOrigin;
    public float laserLength = 10f;
    public Color laserColor = Color.red;
    public float lineWidth = 0.05f;
    public LayerMask hitLayers;

    [Header("Damage Settings")]
    public bool lethalToPlayer = true;
    private LineRenderer lr;

    GameManager gameManager;


    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
        lr.startWidth = lineWidth;
        lr.endWidth = lineWidth;
        lr.material = new Material(Shader.Find("Unlit/Color"));
        lr.material.color = laserColor;

        if (laserOrigin == null)
            laserOrigin = transform;
    }

    void FixedUpdate()
    {
        EmitLaser();
    }

    void EmitLaser()
    {
        Vector3 origin = laserOrigin.position;
        Vector3 direction = laserOrigin.forward;

        Ray ray = new Ray(origin, direction);
        RaycastHit hit;

        Vector3 endPosition;

        if (Physics.Raycast(ray, out hit, laserLength, hitLayers))
        {
            endPosition = hit.point;
            CapsuleCollider cc = hit.collider as CapsuleCollider;
            gameManager = GameManager.instance;

            if (cc!=null&& cc.CompareTag("Player"))
            {
                Debug.Log("Player hit by laser!");
                cc.GetComponent<PlayerController>()?.Die();
                gameManager.PlayerDie();
                
            }
        }
        else
        {
            endPosition = origin + direction * laserLength;
        }

        lr.SetPosition(0, origin);
        lr.SetPosition(1, endPosition);
    }
    
}
