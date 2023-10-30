// MoveToClickPoint.cs
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour {
    NavMeshAgent agent;
    LineRenderer lineRenderer; 
    
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
        
        agent.updateRotation=false;
        lineRenderer.startWidth = 0.25f;
        lineRenderer.endWidth = 0.25f;
        lineRenderer.positionCount = 0;
    }
    
    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject()) {
            ClickToMove();
        }

        if (agent.hasPath){
            DrawPath();
        }
    }

    // use raycast to move player 
    void ClickToMove() {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
            agent.destination = hit.point;
        }
    }

    // visible pathing
    void DrawPath() {
        lineRenderer.positionCount = agent.path.corners.Length;
        lineRenderer.SetPosition(0,transform.position);

        if (agent.path.corners.Length < 2) {
            return;
        }

        for (int i=1; i<agent.path.corners.Length; i++){
            Vector3 pointPosition = new Vector3(agent.path.corners[i].x, agent.path.corners[i].y, agent.path.corners[i].z);
            lineRenderer.SetPosition(i, pointPosition);
        }
    }
}
