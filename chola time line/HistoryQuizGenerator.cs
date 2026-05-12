using UnityEngine;

public class HistoryQuizGenerator : MonoBehaviour
{
    public HistoricalDataset dataset;

    public string GenerateQuestion()
    {
        var ev = dataset.events[Random.Range(0, dataset.events.Count)];
        return $"In which year did the {ev.title} occur?";
    }
}
