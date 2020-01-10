using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    //Trigger

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}(Tag : {other.tag}) Trigger Enter3D!");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"{other.name}(Tag : {other.tag}) Trigger Stay3D!");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.name}(Tag : {other.tag}) Trigger Exit3D!");
    }


    //Collision

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}(Tag : {collision.gameObject.tag}) Collision Enter3D!");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}(Tag : {collision.gameObject.tag}) Collision Stay3D!");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name}(Tag : {collision.gameObject.tag}) Collision Exit3D!");
    }
}
