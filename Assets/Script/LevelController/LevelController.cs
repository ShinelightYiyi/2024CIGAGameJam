using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    public static LevelController Instance = null;


    GameObject passPanel;
    Animator passAni;

    private void Start()
    {
        Debug.LogWarning("ʵ����");
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        passPanel = GameObject.FindGameObjectWithTag("Pass");
        passAni = passPanel.GetComponent<Animator>();
        EventCenter.Instance.AddEventListener<string>("��һ��", (o) => ChangeScene(o));
    }


    private void ChangeScene(string sceneName)
    {
        EventCenter.Instance.Clear();
        Debug.LogWarning("����");
        SceneController.Instance.LoadSceneAsync(sceneName);
        passAni.SetTrigger("passAway");
        EventCenter.Instance.AddEventListener<float>("���ȼ���", (o) => PassIn(o));
    //    EventCenter.Instance.AddEventListener<string>("��һ��", (o) => ChangeScene(o));
    }

    private void PassIn(float o)
    {
        if(o == 1)
        {
            passAni.SetTrigger("passIn");
        }
    }
    


}