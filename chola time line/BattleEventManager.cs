using UnityEngine;

public class BattleEventManager : MonoBehaviour
{
    public HistoricalDataset dataset;

    public HistoricalEvent GetBattle(string name)
    {
        foreach (var ev in dataset.events)
            if (ev.category == "Battle" && ev.title.Contains(name))
                return ev;
        return null;
    }
}
