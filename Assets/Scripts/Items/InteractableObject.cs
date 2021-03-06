﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class InteractableObject : MonoBehaviour
{

    GameObject player;
    public string id;
    Transform anchorPosHand;
    Transform anchorPosElbow;
    Transform target;
    public bool taken;
    // Use this for initialization
    AstarPath path;


    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Gladiator")
        {
            other.gameObject.GetComponent<GladiatorShooting>().PickUpObject(this.gameObject, id);
            GameElements.itemSpawned.Remove(gameObject);
            if (id == "fireweapon")
            {

                transform.FindChild("ItemAura").gameObject.SetActive(false);
                gameObject.GetComponent<BoxCollider>().enabled = false;
                //gameObject.transform.SetParent(other.transform);
                anchorPosHand = other.gameObject.GetComponent<GladiatorShooting>().handPosition;
                anchorPosElbow = other.gameObject.GetComponent<GladiatorShooting>().elbowPosition;
                taken = true;
                gameObject.transform.parent = anchorPosHand;
                gameObject.transform.position = anchorPosHand.position;
                GameElements.setWeaponDropped(false);
                gameObject.GetComponent<Indicator>().enabled = false;
               
            }
            else if (id == "weapon")
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                
                anchorPosHand = other.gameObject.GetComponent<GladiatorShooting>().handPosition;
                anchorPosElbow = other.gameObject.GetComponent<GladiatorShooting>().elbowPosition;

                taken = true;
            }
            else if (id == "medpack")
            {
                GameElements.setMedDropped(false);

                gameObject.SetActive(false);
                Destroy(gameObject);
            }
            else if (id == "armor")
            {
                GameElements.setArmorDropped(false);

                gameObject.SetActive(false);
                Destroy(gameObject);
            }else if (id == "grenade")
            {
                GameElements.setWeaponDropped(false);
                Destroy(gameObject);
            }

            else
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {

        if (taken)
        {
            
            //gameObject.transform.position = new Vector3(anchorPosHand.position.x, anchorPosHand.position.y, anchorPosHand.position.z);
            gameObject.transform.rotation = new Quaternion(Quaternion.LookRotation(anchorPosHand.position - anchorPosElbow.position).x,
                                                           Quaternion.LookRotation(anchorPosHand.position - anchorPosElbow.position).y,
                                                           Quaternion.LookRotation(anchorPosHand.position - anchorPosElbow.position).z,
                                                           Quaternion.LookRotation(anchorPosHand.position - anchorPosElbow.position).w);

        }
    }

    void OnDestroy()
    {
        GameElements.itemSpawned.Remove(gameObject);
    }
}