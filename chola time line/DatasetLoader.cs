using UnityEngine;
using System.IO;

public class DatasetLoader : MonoBehaviour
{
    public HistoricalDataset dataset;

    void Start()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/CholaEvents.json");
        JsonUtility.FromJsonOverwrite(json, dataset);
    }
}
DatasetLoader.cs