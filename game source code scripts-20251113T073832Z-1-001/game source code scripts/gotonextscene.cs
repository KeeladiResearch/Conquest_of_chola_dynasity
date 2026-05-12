using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class gotonextscene : MonoBehaviour
{
    private PlayableDirector director;


    private void Start()
    {
        director.Stop();
        director = GetComponent<PlayableDirector>();
        director.stopped += Director_stopped;
    }

    private void Director_stopped(PlayableDirector obj)
    {
        loader.Load(loader.scene.game);
    }

    private void OnDestroy()
    {
        director.stopped -= Director_stopped;
    }
}
