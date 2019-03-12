using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 対象の大きさを調整
    /// </summary>
    public class Scaler : MonoBehaviour
    {
        /// <summary>
        /// 大きさを調整する対象
        /// </summary>
        [SerializeField]
        Transform Target;

        /// <summary>
        /// アスペクト比？(縦/横)
        /// </summary>
        [SerializeField]
        float Ratio;

        /// <summary>
        /// 速さ調整
        /// </summary>
        [SerializeField]
        float Gain;

        void Update()
        {
            var scale = Vector3.Distance(transform.position, Target.position) * Gain;
            Target.localScale = new Vector3(scale, scale * Ratio, Target.localScale.z);
            var box = transform.parent.GetComponent<BoxCollider>();
            if (box != null)
            {
                box.size = Target.localScale;
            }
        }
    }
}
