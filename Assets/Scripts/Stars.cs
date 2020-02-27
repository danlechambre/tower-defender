using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    private GameUI ui;

    [SerializeField]
    private int currentStars = 100;

    private void Start()
    {
        ui = FindObjectOfType<GameUI>();
        if (!ui)
        {
            Debug.LogError("Could not locate a UI");
        }
        else
        {
            ui.UpdateStarsUI(currentStars);
        }
    }

    public bool HasEnoughStars(int stars)
    {
        bool hasEnoughStars;
        if (stars > currentStars)
        {
            hasEnoughStars = false;
        }
        else
        {
            hasEnoughStars = true;
        }

        return hasEnoughStars;
    }

    public void SpendStars(int stars)
    {
        if (!HasEnoughStars(stars))
        {
            return;
        }
        else
        {
            currentStars -= stars;
            ui.UpdateStarsUI(currentStars);
        }
    }

    public int GetCurrentStars()
    {
        return currentStars;
    }

    public void AddStars(int stars)
    {
        currentStars += stars;
        ui.UpdateStarsUI(currentStars);
    }
}
