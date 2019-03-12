using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// カメラのFoVを距離で設定
    /// </summary>
    public class SetFoV : MonoBehaviour
    {
        /// <summary>
        /// FoVを操作する対象のカメラ
        /// </summary>
        [SerializeField]
        Camera Target;

        /// <summary>
        /// 速さ調整
        /// </summary>
        [SerializeField]
        float Gain;

        void Update()
        {
            var fov = Vector3.Distance(transform.position, Target.gameObject.transform.position);
            Target.fieldOfView = Mathf.Clamp(fov * Gain, 1, 179);
        }
    }
}
