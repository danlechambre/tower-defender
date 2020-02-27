using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    private Defender defenderPrefab;
    private DefenderSpawner dSpawner;

    Transform buttons;

    Image img;
    Text costTxt;

    private void Start()
    {
        dSpawner = FindObjectOfType<DefenderSpawner>();
        if (!dSpawner)
        {
            Debug.LogError($"{this.name} could not get DefenderSpawner.");
            return;
        }

        if (!defenderPrefab)
        {
            Debug.LogError($"{this.name} has no DefenderPrefab assigned in the inspector!");
            return;
        }

        img = GetComponent<Image>();
        costTxt = transform.GetChild(0).GetComponent<Text>();
        costTxt.text = defenderPrefab.GetCost().ToString();

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
        dSpawner.SetDefenderPrefab(defenderPrefab);
    }
}