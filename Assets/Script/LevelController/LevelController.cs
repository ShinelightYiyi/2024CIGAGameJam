using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{




    GameObject passPanel;
    Animator passAni;

    private void Start()
    {

        passPanel = GameObject.FindGameObjectWithTag("Pass");
        passAni = passPanel.GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<string>("下一关", (o) => ChangeScene(o));
    }


    private void ChangeScene(string sceneName)
    {
        EventCenter.Instance.Clear();
        Debug.LogWarning("加载");
        SceneController.Instance.LoadSceneAsync(sceneName);
        passAni.SetTrigger("passAway");
        EventCenter.Instance.AddEventListener<float>("进度加载", (o) => PassIn(o));
    //    EventCenter.Instance.AddEventListener<string>("下一关", (o) => ChangeScene(o));
    }

    private void PassIn(float o)
    {
        if(o == 1)
        {
            passAni.SetTrigger("passIn");
        }
    }
    


}
