using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

	public float v_forcaPulo;
	public AudioClip v_PuloAudioClip;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Rigidbody2D v_rigidBody = GetComponent<Rigidbody2D>();
		float v_movimento = Input.GetAxis("Horizontal"); // Cria um movimento na horizontal eixo x		
		
		v_rigidBody.velocity= new Vector2(v_movimento * 2, v_rigidBody.velocity.y);
		
		VirarEsquerdaDireita(v_movimento);

		AndarParar(v_movimento);
		v_rigidBody.AddForce(new Vector2(0,v_forcaPulo)); // Adicionar força ao pulo eixo x

		pular(v_forcaPulo, v_rigidBody);		
	}

	/**
	 Fazendo personangem andar (com animação)
	*/
	void AndarParar(float v_movimento) {
		
		if(v_movimento > 0 || v_movimento <0 ){
			GetComponent<Animator>().SetBool("Se_Andando", true);
		} else{
			GetComponent<Animator>().SetBool("Se_Andando", false);
		}
	}

	void VirarEsquerdaDireita(float v_movimento){
		if(v_movimento < 0) { // Se personagem andando para esquerda
		
			GetComponent<SpriteRenderer>().flipX = true; // Aplique o flip
		} else if(v_movimento>0) { // Se personagem andando para direita
		
			GetComponent<SpriteRenderer>().flipX = false; // Não aplique o flip
		}
	}

	void pular(float v_forcaPulo,Rigidbody2D v_rigidBody){
		
		if(Input.GetKeyDown(KeyCode.Space)) // Ao pressionar a tecla espaço o Personagem pula.
		{
			v_rigidBody.AddForce(new Vector2(0,v_forcaPulo)); // Adicionar força ao pulo eixo x
            GetComponent<AudioSource>().PlayOneShot(v_PuloAudioClip); // Toca o som do pulo
		}
	}
}
