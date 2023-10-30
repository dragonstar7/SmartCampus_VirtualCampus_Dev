using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOne : MonoBehaviour
{
   Vector3 tpLocation = new Vector3(-33.45f, 63f, 164.6f);
  
    void OnTriggerEnter(Collider Col)
    {
         CharacterController player = Col.gameObject.GetComponent<CharacterController>();
        player.enabled = false;
        player.transform.position = tpLocation;
        player.enabled = true;
            
//Teleport from Green Enterance to Green Base
            
        
    }
}
//Green Base Empty (0,0,0)
//Green Base (-1.6,50,-103.2)
//Green Enterence (146.6,-5.4,114.3)