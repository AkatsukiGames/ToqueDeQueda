using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishArea : MonoBehaviour
{
    public GameObject player;
    public GameObject WinText;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player") {
            WinText.GetComponent<Text>().enabled = true;
        }
    }
}
