using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraFollowing : MonoBehaviour
{
    // Start is called before the first frame update
    public float followSpeed = 2.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Transform target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 targetPosition = Camera.main.WorldToViewportPoint(target.position);//����Ŀ������Ļ�Ϸ���λ��
        Vector3 delta = target.position - Camera.main.WorldToViewportPoint(new Vector3(0.5f, 0.5f, target.position.z));//�����Ӧ���ƶ�������
        Vector3 destination = transform.position - delta;//�����������Ŀ��λ��
        transform.position = Vector3.Lerp(transform.position, destination, followSpeed * Time.deltaTime);//���ս��

    }
}
