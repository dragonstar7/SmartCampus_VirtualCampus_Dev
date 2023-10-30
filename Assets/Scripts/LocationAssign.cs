using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationAssign : MonoBehaviour
{
    public int locationIndex; //assigned in inspector
    public GameObject UIManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void MovePlayer()
    {
        UIManager.GetComponent<MenuButtons>().MovePlayer(locationIndex);
    }
}
