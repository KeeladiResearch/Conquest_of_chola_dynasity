using System;

[Serializable]
public class HistoricalEvent
{
    public string eventId;
    public string title;
    public string description;
    public int year;
    public string location;
    public string category; // e.g., "Battle", "Cultural", "Ruler"
}
