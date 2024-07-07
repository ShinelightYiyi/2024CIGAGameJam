using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public string thisLevel;

    Camera camera;

    GameObject passObj;
    Animator passAni;

    private void Awake()
    {
        passObj = GameObject.FindGameObjectWithTag("Pass");
        passAni = passObj.GetComponent<Animator>();
        camera = Camera.main;
        EventCenter.Instance.AddEventListener("死亡", () => Die());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            passAni.SetTrigger("dieOut");
            EventCenter.Instance.Clear();
            SceneController.Instance.LoadSceneAsync(thisLevel);
            EventCenter.Instance.AddEventListener<float>("进度加载", (o) => BuildLevel(o));
        }
    }


    private void Die()
    {
        camera.DOShakePosition(0.3f, 1f);
        passAni.SetTrigger("dieOut");
        EventCenter.Instance.Clear();
        SceneController.Instance.LoadSceneAsync(thisLevel);
        EventCenter.Instance.AddEventListener<float>("进度加载",(o)=>BuildLevel(o));
    }   
    
    private void BuildLevel(float o)
    {
        if(o == 1)
        {
            passAni.SetTrigger("dieIn");
        }
    }
}
