using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName="CholaDataset", menuName="Chola/History Dataset")]
public class HistoricalDataset : ScriptableObject
{
    public List<HistoricalEvent> events = new List<HistoricalEvent>();

    public HistoricalEvent GetEventById(string id)
        => events.Find(e => e.eventId == id);
}
