using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SceneStudio
{
    /// <summary>
    /// トリガーとグリップの入力を取得
    /// </summary>
    public class SteamVR_Clench : MonoBehaviour
    {
        /// <summary>
        /// 謎
        /// </summary>
        [SerializeField]
        SteamVR_ActionSet ActionSet;

        /// <summary>
        /// トリガー入力の取得元
        /// </summary>
        [SerializeField]
        SteamVR_Action_Boolean GrabPinch;

        /// <summary>
        /// グリップ入力の取得元
        /// </summary>
        [SerializeField]
        SteamVR_Action_Boolean GrabGrip;

        /// <summary>
        /// 謎
        /// </summary>
        Interactable Interactable;

        protected void Init()
        {
            Interactable = GetComponent<Interactable>();
            Interactable.activateActionSetOnAttach = ActionSet;
        }

        protected bool IsClench()
        {
            if (Interactable.attachedToHand)
            {
                var hand = Interactable.attachedToHand.handType;
                var GripPinch = GrabPinch.GetStateDown(hand) && GrabGrip.GetState(hand);
                var PinchGrip = GrabPinch.GetState(hand) && GrabGrip.GetStateDown(hand);
                if (GripPinch || PinchGrip)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
