using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chose_panel : MonoBehaviour {


    //弾
    public GameObject bullet;
    public float speed = 1000000;

    //コントローラーの位置
    [SerializeField]
    private Transform right_hand;
    [SerializeField]
    private Transform left_hand;
    [SerializeField]
    private Transform center_eye;

    // コントローラーの取得
    private Transform Pointer {
        get {
            //現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote) {
                return right_hand;
            } else if (controller == OVRInput.Controller.LTrackedRemote) {
                return left_hand;
            } else {
                //両手のコントローラーを検出できなかった場合目の間を返す
                return center_eye;
            }
        }
    }

    void Update() {
        var pointer = Pointer;
        if (pointer == null) {
            return;
        } else {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) {
                //弾のインスタンスを作成
                GameObject bullets = Instantiate(bullet, pointer.position, pointer.rotation);
                //速度決定
                var force = pointer.forward * speed;
                //弾発射(質量無視)
                bullets.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
                //弾の向き調整
                bullets.transform.position = pointer.position;
            }
        }

    }
}
