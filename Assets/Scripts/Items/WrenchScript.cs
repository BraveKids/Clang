﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class WrenchScript : NetworkBehaviour {
    public float m_Damage;

	// Use this for initialization
	void Start () {
        
	}
	
	
     void OnTriggerEnter(Collider obj)
    {
        if (obj.tag =="Enemy" || obj.tag == "Wurm" || obj.tag == "Tank")
        {
            /*
            if (obj.gameObject.tag == "Tank")
            {
                obj.gameObject.GetComponentInParent<TankAI>().isDamaged = true;
            }*/
            obj.GetComponentInParent<EnemyHealth>().Damage(m_Damage);


        }
    }
}
