using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidade;
    private Vector2 direcao;
    private Rigidbody2D rb;
    private bool isLookRight = true;

    public Animator anim;

    // Start is called before the first frame update

    // PEGAR REFERENCIAS NA INICIALIZACAO
    void Awake()
    {
        // LINKA AUTOMATICAMENTE O RIGIDBODY2D DO PLAYER
        // SE NÃO TIVER DA ERRO
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        velocidade = 3f;
        direcao = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {

        InputPersonagem();
        transform.Translate(direcao * velocidade * Time.deltaTime);


        float directionx = Input.GetAxisRaw("Horizontal");
        //float directiony = Input.GetAxisRaw("Vertical");
        if (directionx > 0 && !isLookRight)
        {
            // INVERTE SUA DIREÇÃO PRA OLHAR PRA DIREÇÃO CERTA
            // EXECUTA O MÉTODO Turn
            Turn();
        }
        // SE ELE ESTIVER OLHANDO PRA DIREITA E A DIREÇÃO FOR PRA ESQUERDA
        else if (directionx < 0 && isLookRight)
        {
            // INVERTE SUA DIREÇÃO PRA OLHAR PRA DIREÇÃO CERTA
            // EXECUTA O MÉTODO Turn
            Turn();
        }
    }
    // MÉTODO PRA VIRAR O PLAYER PARA O LADO CERTO DAS TECLAS
    void Turn()
    {
        // INVERTER A DIREÇÃO, ESQUERDA --> DIREITA E VICE VERSA
        // NO CASO VAI INVERTER DE TRUE --> FALSE E VICE VERSA
        isLookRight = !isLookRight;
        // PEGAR A ESCALA DO PLAYER
        Vector3 scale = transform.localScale;
        // MULTIPLICA O VALOR DE X PARA INVERTER ESQUERDA --> DIREITA ...
        scale.x *= -1;
        // SETA O VALOR DA ESCALA PARA O VALOR MODIFICADO
        transform.localScale = scale;

    }

    void InputPersonagem()
    {
        direcao = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            direcao += Vector2.up;
            anim.SetBool("isDuck", true);
            anim.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector2.down;
            anim.SetBool("isDuck", false);
            anim.SetBool("isRight", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direcao += Vector2.left;
            anim.SetBool("isRight", true);
            anim.SetBool("isDuck", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direcao += Vector2.right;
            anim.SetBool("isRight", true);
            anim.SetBool("isDuck", false);
        }
    }

}
