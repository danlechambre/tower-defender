using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    private Text starsText;

    [SerializeField]
    private int currentStars = 100;

    private void Start()
    {
        starsText = GameObject.Find("Stars txt").GetComponent<Text>();
        if (!starsText)
        {
            Debug.LogError("Could not find Stars GameObject");
        }
        else
        {
            UpdateStarsUI();
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
            UpdateStarsUI();
        }
    }

    private void UpdateStarsUI()
    {
        starsText.text = currentStars.ToString();
    }

    public int GetCurrentStars()
    {
        return currentStars;
    }

    public void AddStars(int stars)
    {
        currentStars += stars;
        UpdateStarsUI();
    }
}
