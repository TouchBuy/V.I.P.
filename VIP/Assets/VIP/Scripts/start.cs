using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour {

    //startが押されたらカテゴリ一覧に飛ぶ
    public void OnClick() {
        SceneManager.LoadScene("Category");
    }
}
