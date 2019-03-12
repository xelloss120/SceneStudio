using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SceneStudio
{
    /// <summary>
    /// スティック(パッド)の入力を取得
    /// </summary>
    public class SteamVR_Vector2 : MonoBehaviour
    {
        /// <summary>
        /// スティック(パッド)入力の取得値
        /// </summary>
        protected Vector2 Axis;

        /// <summary>
        /// 謎
        /// </summary>
        [SerializeField]
        SteamVR_ActionSet ActionSet;

        /// <summary>
        /// スティック(パッド)入力の取得元
        /// </summary>
        [SerializeField]
        SteamVR_Action_Vector2 ActionVec2;

        /// <summary>
        /// 謎
        /// </summary>
        Interactable Interactable;

        protected void Init()
        {
            Interactable = GetComponent<Interactable>();
            Interactable.activateActionSetOnAttach = ActionSet;
        }

        protected bool UpdateAxis()
        {
            if (Interactable.attachedToHand)
            {
                Axis = ActionVec2.GetAxis(Interactable.attachedToHand.handType);
                return true;
            }
            return false;
        }
    }
}
