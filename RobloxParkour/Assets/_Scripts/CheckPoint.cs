using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("X", this.transform.parent.position.x);
            PlayerPrefs.SetFloat("Y", this.transform.parent.position.y);
            PlayerPrefs.SetFloat("Z", this.transform.parent.position.z);
            
            other.transform.gameObject.GetComponent<PlayerController>()._savedPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
        }
    }
}
