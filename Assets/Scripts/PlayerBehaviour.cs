﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    [SerializeField] private List<ButtonInteraction> _currentJobs;
    [SerializeField] private FingerInteraction[] _fingers;
    public List<ButtonInteraction> CurrentJobs => _currentJobs;

    private ButtonInteraction _activeJob;
    public ButtonInteraction ActiveJob => _activeJob;

    private float _reward;
    public float Reward {
        get { return _reward; }
        set { _reward = value; _scoreText.text = Reward.ToString(); }
    }

    public void GetJobs(GameObject[] sceneObjects)
    {
        _currentJobs.Clear();

        foreach (var job in sceneObjects)
        {
            var jobComponent = job.GetComponent<JobStorage>();
            if (jobComponent)
            {
                _currentJobs = jobComponent.JobButtons;
                jobComponent.FinishedItemBox.Player = this;
                foreach (var finger in _fingers)
                {
                    finger._furnaceManager = jobComponent.FurnaceManager;
                }
            }
        }
    }

    public void SetActiveJob(ButtonInteraction newJob)
    {
        if (!_activeJob)
        {
            _activeJob = newJob;
            _activeJob.ButtonColour.color = _activeJob.ActiveColour;
        }

        if (_activeJob != newJob)
        {
            //new job logic goes here
            //reset active job colour
            
            _activeJob.ButtonColour.color = _activeJob.InactiveColour;
            newJob.ButtonColour.color = newJob.ActiveColour;
            //active job = new job
            _activeJob = newJob;
        }
    }
}
