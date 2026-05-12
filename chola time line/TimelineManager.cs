using UnityEngine;
using System.Linq;

public class TimelineManager : MonoBehaviour
{
    public HistoricalDataset dataset;

    public void DisplayTimeline()
    {
        var ordered = dataset.events.OrderBy(e => e.year);
        foreach (var ev in ordered)
            Debug.Log($"{ev.year}: {ev.title}");
    }
}
