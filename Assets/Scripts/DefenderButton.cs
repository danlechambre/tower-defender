using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    Transform buttons;

    Image img;

    private void Start()
    {
        img = GetComponent<Image>();
        buttons = GameObject.Find("Buttons").GetComponent<Transform>();

        foreach (Transform b in buttons)
        {
            b.GetComponent<Image>().color = Color.grey;
        }
    }

    public void SetActive()
    {
        foreach (Transform b in buttons)
        {
            b.GetComponent<Image>().color = Color.grey;
        }

        img.color = Color.white;
    }
}
