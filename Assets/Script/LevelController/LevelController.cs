using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    GameObject passPanel;
    Animator passAni;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        passPanel = GameObject.FindGameObjectWithTag("Pass");
        passAni = passPanel.GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<string>("��һ��", (o) => ChangeScene(o));
    }


    private void ChangeScene(string sceneName)
    {
        EventCenter.Instance.Clear();
        SceneController.Instance.LoadSceneAsync(sceneName);
        passAni.SetTrigger("passAway");
        EventCenter.Instance.AddEventListener<float>("���ȼ���", (o) => PassIn(o));
    }

    private void PassIn(float o)
    {
        if(o == 1)
        {
            passAni.SetTrigger("passIn");
        }
    }
    


}
