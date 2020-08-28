using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour
{
    public Button BackBtn;
    private AssetBundle assetBundle;
    // Start is called before the first frame update
    void Start()
    {
        BackBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HelpScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
