using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    [SerializeField] float speed = 6f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] bool isJump; //Variavel para verificar se o personagem está pulando
    [SerializeField] bool inFloor = true; //Variavel para verificar se o personagem está no chão
    [SerializeField] Transform groundCheck; 
    [SerializeField] LayerMask groundLayer; //Variavel para checar a camada

    private void Awake(){
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        inFloor = Physics2D.Linecast(transform.position, groundCheck.position, groundLayer);
        Debug.DrawLine(transform.position, groundCheck.position, Color.blue);

        if (Input.GetButtonDown("Jump") && inFloor) {
            isJump = true;
        } else if (Input.GetButtonUp("Jump") && rbPlayer.velocity.y > 0) {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate(){
        Move();
        JumpPlayer();
    }

    void Move(){
        float xMove = Input.GetAxis("Horizontal"); //Aqui estamos pegando as teclas para o personagem se movimentar
        rbPlayer.velocity = new Vector2(xMove * speed, rbPlayer.velocity.y);

        /* O método abaixo faz com o que o personagem mude a direção do rosto conforme o lado para qual ele vai
        if (xMove > 0) { //Direita
            transform.eulerAngles = new Vector2(0,0);
        } else if (xMove < 0){ //Esquerda
            transform.eulerAngles = new Vector2(0,180);
        }*/
    }

    void JumpPlayer(){
        if (isJump) {
            rbPlayer.velocity = Vector2.up * jumpForce;
            isJump = false;
        }
    }
}
