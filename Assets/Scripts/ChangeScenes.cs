using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public Button StartBtn;
    public Button HelpBtn;
    private AssetBundle assetBundle;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });

        HelpBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HelpScene");
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
