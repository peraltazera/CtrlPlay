Playerusing System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sensibilidadeMouse = 100f;
    public Transform jogador;
    float rotacaoX = 0f;

    public CharacterController controller;
    public float velocidade = 4.0f;
    public float gravidade = -9.81f;

    Vector3 aceleracao;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadeMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadeMouse * Time.deltaTime;

        rotacaoX -= mouseY;
        rotacaoX = Mathf.Clamp(rotacaoX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotacaoX, 0f, 0f);
        jogador.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * velocidade * Time.deltaTime);

        aceleracao.y += gravidade * Time.deltaTime;
        controller.Move(aceleracao * Time.deltaTime);
    }
}
