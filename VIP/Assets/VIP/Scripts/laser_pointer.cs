using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser_pointer : MonoBehaviour {
    [SerializeField]
    public GameObject genre_panel;
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
            //コントローラーのトリガーが押されているとき,レーザーがパネルにあたっていたら
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)
                && hitInfo.collider.gameObject.tag == "panel") {
                //パネル一覧を取得のち選択されてない要素を削除
                foreach (Transform child in genre_panel.transform) {
                    if (child == hitInfo.collider.gameObject.transform) {
                        continue;
                    }
                    Destroy(child.gameObject);
                }
            }
        } else {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            laser_pointer_renderer.SetPosition(1, pointerRay.origin + pointerRay.direction * max_distance);
        }
    }
}
