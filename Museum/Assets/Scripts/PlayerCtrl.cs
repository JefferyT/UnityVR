using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum : 어떤 상태나 타입 구분할때
public enum MoveType
{
    WayPoint=0,
    Eye=1
}

public class PlayerCtrl : MonoBehaviour
{
    //이동 타입을 정함
    public MoveType moveType;

    //웨이포인트 그룹
    public GameObject WayPointGroup;
    //포인트들
    public Transform[] points;

    public int idx;
    public bool isMove;

    //처음 시작할때 1번
    void Start()
    {
        points = WayPointGroup.GetComponentsInChildren<Transform>();
        idx = 1;
        isMove = true;
    }

    void Update()
    {
        Move();
    }
    public void Move()
    {
        if (!isMove) return;
        if (moveType == MoveType.WayPoint)
        {

            //방향값 : 내가 갈 포인트까지의
            Vector3 dir = points[idx].position - this.transform.position;

            //회전값
            Quaternion rot = Quaternion.LookRotation(dir);

            //회전해주기
            this.transform.rotation = Quaternion.Slerp(
                this.transform.rotation, rot, Time.deltaTime * 3f);

            //이동해주기
            this.transform.Translate(Vector3.forward * Time.deltaTime * 3f);

        }
        else if (moveType == MoveType.Eye)
        {
            Vector3 dir = Camera.main.transform.TransformDirection(Vector3.forward);
            this.transform.Translate(dir * Time.deltaTime);
        }
    }

    //충돌체랑 처음 충돌했을떄
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "POINT")
        {
            idx++;
            if (idx >= points.Length) idx = 1;
        }
    }
}
