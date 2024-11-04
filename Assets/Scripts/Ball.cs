using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //���� �Ŀ�
    public float jumpPower;
    //���� �ִ� �ӵ�
    public float maxSpeed;
    //�����̴� ��
    public float movePower;

    Rigidbody rb;

    private void Start()
    {   //���� �ʱ�ȭ
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //�������(X)
        float h = Input.GetAxisRaw("Horizontal");
        //��������(Z)
        float v = Input.GetAxisRaw("Vertical");
        //���͸� ī�޶��� ���� ��ǥ�� �������� ��ȯ
        Vector3 direction = Camera.main.transform.TransformDirection(h, 0, v);
        //���� �� ���ϱ�
        rb.AddForce(movePower * direction, ForceMode.Force);
        //������� �ӵ�
        Vector2 horizontalVelocity = new Vector2(rb.velocity.x, rb.velocity.z);
        //�ִ�ӷ� ����
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(horizontalVelocity.x, rb.velocity.y, rb.velocity.z);
        }

        /*float h = Input.GetAxisRaw("Horizontal"); //�������
        float v =Input.GetAxisRaw("Vertical"); //��������
        Vector3 direction = new Vector3(h,0, v).normalized; 
        direction=Camera.main.transform.TransformDirection(direction);
        direction.y = 0;*/
    }

    void OnCollisionEnter(Collision collision)
    {
        //���� �ٴ��� ������
        if (collision.gameObject.name == "Floor")
        {
            //y�� �������� ƨ���
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);

        }
    }

}