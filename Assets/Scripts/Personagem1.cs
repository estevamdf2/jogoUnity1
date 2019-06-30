using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem1 : MonoBehaviour {

	public float v_forcaPulo;
    public AudioClip v_PuloAudioClip;


	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update ()
        {

        if (Input.GetKeyDown(KeyCode.Space)) // Faz boneco saltar quando teclar espaço
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 200)); // Adiciona força no salto do boneco
        }

	
		Rigidbody2D v_ridiBody = GetComponent<Rigidbody2D>();

		float v_movimento = Input.GetAxis("Horizontal"); // Cria um movimento na horizontal eixo x

		v_ridiBody.velocity= new Vector2(v_movimento*2, v_ridiBody.velocity.y);

		if(v_movimento<0) // Se personagem andando para esquerda
		{
			GetComponent<SpriteRenderer>().flipX = true; // Aplique o flip
		} else if(v_movimento>0) // Se personagem andando para direita
		{
			GetComponent<SpriteRenderer>().flipX = false; // Não aplique o flip
		}
        // Fazendo o personagem andar
        if(v_movimento > 0 || v_movimento < 0)
        {
            GetComponent<Animator>().SetBool("Se_Andando", true);
        } else
        {
            GetComponent<Animator>().SetBool("Se_Andando", false);
        }
		if(Input.GetKeyDown(KeyCode.Space)) // Ao pressionar a tecla espaço o Personagem pula.
		{
			v_ridiBody.AddForce(new Vector2(0,v_forcaPulo)); // Adicionar força ao pulo eixo x
            GetComponent<AudioSource>().PlayOneShot(v_PuloAudioClip); // Toca o som do pulo
		}
	}
}
