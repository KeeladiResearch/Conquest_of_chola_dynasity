using UnityEngine;

public class CholaMapMarker : MonoBehaviour
{
    public string eventId;

    void OnMouseDown()
    {
        var ev = FindObjectOfType<HistoricalDataset>().GetEventById(eventId);
        Debug.Log($"Selected: {ev.title}");
    }
}
