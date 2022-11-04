using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int Oranges = 0;
    [SerializeField] private TextMeshProUGUI OrangesText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Orange"))
        {
            Destroy(collision.gameObject);
            Oranges++; 
            OrangesText.text = "Oranges: " + Oranges;
        }
    }
}
