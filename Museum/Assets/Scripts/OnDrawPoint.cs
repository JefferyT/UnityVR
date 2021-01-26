using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrawPoint : MonoBehaviour
{
	public Transform[] points;
	public void OnDrawGizmos()
	{
		//그 서랍에 자식들의 웨이포티를 가져온다.
		points = this.GetComponentsInChildren<Transform>();

		//반복문을 통해 1-2연결 , 2-3연결,3-4연결
		for (int i = 1; i < points.Length - 1; i++)
		{
			Gizmos.DrawLine(points[i].position, points[i + 1].position);
		}
		//4-1연결
		Gizmos.DrawLine(points[points.Length - 1].position, points[1].position);
	}

}
