using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo2_Controller : MonoBehaviour
{
    public void EnterGame()
    {
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        string[] loadedSceneAssetNames = scene.GetLoadedSceneAssetNames();
        for (int i = 0; i < loadedSceneAssetNames.Length; i++)
        {
            scene.UnloadScene(loadedSceneAssetNames[i]);
        }
        scene.LoadScene("Assets/Demo2/Demo2_Game.unity", this);
    }
}
