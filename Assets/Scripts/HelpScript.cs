using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HelpScript : MonoBehaviour
{
    public Button HelpBtn;
    private AssetBundle assetBundle;
    // Start is called before the first frame update
    void Start()
    {
        HelpBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HomeScene");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
