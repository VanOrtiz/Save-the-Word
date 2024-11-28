using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public void iniciarJogo(){
        SceneManager.LoadScene("EscolhaPersonagem"); //Aqui definimos qual tela será carregada após apertar o botão de Iniciar
    }

    public void creditosJogos(){
        SceneManager.LoadScene("Creditos"); //Aqui definimos qual tela será carregada após apertar o botão de Crédito
    }

    public void fecharJogo(){
        Application.Quit();
        Debug.Log("Fechou o Jogo");
    }
}
