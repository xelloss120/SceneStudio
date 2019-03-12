using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// メッシュの影を非表示に設定
    /// </summary>
    public class SetCastShadows : MonoBehaviour
    {
        /// <summary>
        /// 処理の遅延時間
        /// </summary>
        /// <remarks>
        /// 主にはSteamVR PluginのPrefabが読み込む手のオブジェクトの影を消したい
        /// 上記が参照するPrefabが入れ子になっていて設定済みPrefabを作るのも面倒
        /// ただし、読込処理が走ってからでないと捕まらないので、余裕を持って実行
        /// </remarks>
        [SerializeField]
        float DelayTime;

        void Start()
        {
            Invoke("Set", DelayTime);
        }

        void Set()
        {
            foreach (var child in transform.gameObject.GetComponentsInChildren<MeshRenderer>())
            {
                child.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
            foreach (var child in transform.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                child.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
            }
        }
    }
}
