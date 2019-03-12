using UnityEngine;

namespace SceneStudio
{
    /// <summary>
    /// 親次第でマテリアルを切り替え
    /// </summary>
    public class SwitchingMaterial : MonoBehaviour
    {
        /// <summary>
        /// 親判定の対象
        /// </summary>
        public Transform Target;

        /// <summary>
        /// 親が対象の時のマテリアル
        /// </summary>
        [SerializeField]
        Material TrueMat;

        /// <summary>
        /// 親が対象でない時のマテリアル
        /// </summary>
        [SerializeField]
        Material FalseMat;

        void Update()
        {
            GetComponent<Renderer>().material = transform.parent == Target ? TrueMat : FalseMat;
        }
    }
}
