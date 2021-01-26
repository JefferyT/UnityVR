using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecticleCtrl : MonoBehaviour
{
    public Image recticle;
    public PlayerCtrl pc;
    GameObject temp;

    void Update()
    {
        Vector3 start = this.transform.position; //시작값
        Vector3 dir = this.transform.forward;    //방향값
        RaycastHit hit; //광선에 부딛힌 것들을 넣을곳
        float dis = 5f; //광선 길이
        
        if(Physics.Raycast(start,dir,out hit, dis)){ //광선에 부딛히는게 있다면
            if( hit.collider.tag == "ART") //ART라는 별명을 가진 작품에 부딛히면
            {
                pc.isMove = false; //이동멈추고
                recticle.fillAmount += Time.deltaTime; //게이지 증가
                if( recticle.fillAmount >= 1f) //게이지가 가득차면
                {
                    temp = hit.collider.transform.GetChild(0).gameObject;
                    temp.SetActive(true); //영상 켜기
                }
            }
        }
        else //광선에 부딛히는게 없다면
        {
            pc.isMove = true; //이동 하고
            recticle.fillAmount = 0; //게이지 초기화
            if( temp!=null) temp.SetActive(false); //영상 끄기
        }
       //게임플레이에 안보이는 광선 그리기
        // (시작값 , 방향 * 길이 , 색깔 , 지속시간)
        Debug.DrawRay(start, dir * dis, Color.red, 0.5f);
    }
}
