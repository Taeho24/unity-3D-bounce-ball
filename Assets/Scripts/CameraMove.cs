using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform playerTransform;
    public float mouseSesitivity;
    Vector3 offset;
    float xRotation = 0;
    float yRotation = 0;

    private void Awake()
    {
        playerTransform = GameObject.Find("Ball").transform;
        offset = transform.position - playerTransform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        //���콺 �������� �ð��� ���� �Է¹���
        float mouseX = Input.GetAxis("Mouse X") * mouseSesitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSesitivity * Time.deltaTime;

        //X�� ȸ���� Y��ȸ��
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation += mouseX;

        //���Ϸ� ���� ���ʹϾ����� ��ȯ
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0);
        //ī�޶��� ��ġ
        transform.position = playerTransform.position + (rotation * offset);
        //ī�޶��� ���� ������ ����
        transform.LookAt(playerTransform.position);
    }
}