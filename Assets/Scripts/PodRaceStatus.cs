using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PodRaceStatus : MonoBehaviour
{
    public float BestRecord { get; private set; }
    public float CurrentTime { get; private set; }

    private List<CheckpointScript> passedCheckpoints;

    [SerializeField]
    private FinishLineScript FinishLine;

    [SerializeField]
    private Text checkpointCountText;

    [SerializeField]
    private Text bestRecordText;

    [SerializeField]
    private Text currentRecordText;

    private bool started = false;

    void Start()
    {
        BestRecord = 999f;
        CurrentTime = 0f;
        passedCheckpoints = new List<CheckpointScript>();
        currentRecordText.text = "0";
        bestRecordText.text = "--";
        checkpointCountText.text = passedCheckpoints.Count.ToString() + "/" + FinishLine.GetCheckpointsCount();
    }

    private void Update()
    {
        if (started)
        {
            CurrentTime += Time.deltaTime;
            currentRecordText.text = (Mathf.Round(CurrentTime * 1000) / 1000).ToString("F3");
        }
    }

    public void PassCheckpoint(CheckpointScript checkpoint)
    {
        if (!passedCheckpoints.Contains(checkpoint))
        {
            passedCheckpoints.Add(checkpoint);
            checkpointCountText.text = passedCheckpoints.Count.ToString() + "/" + FinishLine.GetCheckpointsCount();
        }
    }

    public void PassFinishLine(int checkpointQuantity)
    {
        if (!started)
        {
            started = true;
        }
        if (passedCheckpoints.Count == checkpointQuantity)
        {
            if (CurrentTime < BestRecord)
            {
                BestRecord = CurrentTime;
                bestRecordText.text = (Mathf.Round(BestRecord * 1000) / 1000).ToString("F3");
            }
            CurrentTime = 0f;
            passedCheckpoints.Clear();
            checkpointCountText.text = passedCheckpoints.Count.ToString() + "/" + FinishLine.GetCheckpointsCount();
        }
    }
}
