using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


    public static class loader
    {
        public enum scene
        {
            gamestory,
            game,
            load,
        }

        public static scene targetScene;



        public static void Load(scene targetScene)
        {
            loader.targetScene = targetScene;
            SceneManager.LoadScene(scene.load.ToString());

        }

        public static void Loadercallback()
        {
            SceneManager.LoadScene(targetScene.ToString());
        }
    }



