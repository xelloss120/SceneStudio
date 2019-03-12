using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 対象に設定したブレンドシェイプを操作
    /// </summary>
    public class ObjShape : MonoBehaviour
    {
        /// <summary>
        /// バー
        /// </summary>
        [SerializeField]
        Transform Bar;

        /// <summary>
        /// スライダー
        /// </summary>
        [SerializeField]
        Transform Slider;

        /// <summary>
        /// ブレンドシェイプ名表示
        /// </summary>
        [SerializeField]
        TextMesh Text;

        /// <summary>
        /// ブレンドシェイプを持つ対象のメッシュ
        /// </summary>
        SkinnedMeshRenderer Mesh;

        /// <summary>
        /// 対象のブレンドシェイプ番号
        /// </summary>
        int Index;

        /// <summary>
        /// バーの最大位置
        /// </summary>
        float Max;

        public void Init(SkinnedMeshRenderer mesh, int index, string name)
        {
            Mesh = mesh;
            Index = index;
            Text.text = name;
            Max = Bar.localScale.x - Slider.localScale.x;
        }

        void Update()
        {
            // スライダーをバー内に収める
            var vec3 = transform.InverseTransformPoint(Slider.position);
            vec3.y = vec3.z = 0;
            vec3.x = Mathf.Clamp(vec3.x, 0, Max);
            Slider.position = transform.TransformPoint(vec3);

            // ブレンドシェイプにスライダーの位置を適用
            Mesh.SetBlendShapeWeight(Index, vec3.x / Max * 100);
        }
    }
}
