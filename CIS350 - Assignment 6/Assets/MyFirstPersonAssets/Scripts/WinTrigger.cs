using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            winText.SetActive(true);
        }
    }
}
