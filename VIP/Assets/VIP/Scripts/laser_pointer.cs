using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_pointer : MonoBehaviour {
    [SerializeField]
    private Transform right_hand_anchor;
    [SerializeField]
    private Transform left_hand_anchor;
    [SerializeField]
    private Transform center_eye_anchor;
    [SerializeField]
    private LineRenderer laser_pointer_renderer;
    [SerializeField]
    private float max_distance = 100.0f;

    private Transform Pointer {
        get {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote) {
                return right_hand_anchor;
            } else if (controller == OVRInput.Controller.LTrackedRemote) {
                return left_hand_anchor;
            }
            // どちらも取れなければ目の間からビームが出る
            return center_eye_anchor;
        }
    }

    void Update() {
        var pointer = Pointer;
        if (pointer == null || laser_pointer_renderer == null) {
            return;
        }
        // コントローラー位置からRayを飛ばす
        Ray pointerRay = new Ray(pointer.position, pointer.forward);

        // レーザーの起点
        laser_pointer_renderer.SetPosition(0, pointerRay.origin);

        RaycastHit hitInfo;
        if (Physics.Raycast(pointerRay, out hitInfo, max_distance)) {
            // Rayがヒットしたらそこまで
            laser_pointer_renderer.SetPosition(1, hitInfo.point);
        } else {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            laser_pointer_renderer.SetPosition(1, pointerRay.origin + pointerRay.direction * max_distance);
        }
    }
}
