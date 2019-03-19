using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// プレイヤーの大きさ調整
    /// </summary>
    public class PlayerScale : SteamVR_Vector2
    {
        /// <summary>
        /// SteamVR Plugin2系のPlayer Prefab想定
        /// </summary>
        [SerializeField]
        Transform Player;

        /// <summary>
        /// 速さ調整
        /// </summary>
        [SerializeField]
        float Gain;

        void Start()
        {
            Init();
        }

        void Update()
        {
            if (UpdateAxis())
            {
                Player.localScale -= new Vector3(Axis.y, Axis.y, Axis.y) * Player.localScale.x * Gain;
                if (Player.localScale.x > 0.05f)
                {
                    Player.position += new Vector3(0, Axis.y * Player.localScale.y * Gain, 0);// 大きさが変わると視点高さも変わるので調整
                }
                else
                {
                    Player.localScale = Vector3.one * 0.05f;// 下限
                }
            }
        }
    }
}
