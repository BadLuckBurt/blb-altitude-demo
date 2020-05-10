using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;   //required for modding features
using DaggerfallWorkshop;

public class BLBAltitudeDemo : MonoBehaviour
{
    public static Mod Mod {
        get;
        private set;
    }

    [Invoke(StateManager.StateTypes.Start, 0)]
    public static void Init(InitParams initParams)
    {
        Mod = initParams.Mod;  // Get mod     
        new GameObject("BLBAltitudeDemo").AddComponent<BLBAltitudeDemo>(); // Add script to the scene.    
    }

    float deltaTime = 0.0f;

    public void Update() {
        deltaTime += Time.deltaTime;
        if(deltaTime > 5.0f) {
            GameObject player = GameManager.Instance.PlayerObject;
            float altitude = player.transform.position.y;
            altitude += Mathf.Abs(GameManager.Instance.StreamingWorld.WorldCompensation.y);
            float altitudePercentage = (altitude / DaggerfallUnity.Instance.TerrainSampler.MaxTerrainHeight) * 100;
            DaggerfallUI.AddHUDText("Player altitude: " + altitudePercentage.ToString() + "%");
            deltaTime = 0;
        }
    }

    void Awake ()
    {
        Mod.IsReady = true;
    }

}