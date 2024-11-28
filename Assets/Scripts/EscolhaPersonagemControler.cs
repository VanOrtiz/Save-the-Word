using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscolhaPersonagemControler : MonoBehaviour
{
    public GameObject[] personagens; // Array com os botões dos personagens
    public Button botaoProximo;
    public Button botaoAnterior;

    private int indexAtual = 0;

    void Start()
    {
        float aspectRatio = (float)Screen.width / Screen.height;
        foreach (var personagem in personagens){
            RectTransform rt = personagem.GetComponent<RectTransform>();
            if (rt != null){
                rt.sizeDelta = new Vector2(400 * aspectRatio, 550 * aspectRatio);
            }
        }
        // Verifique se os botões e o array estão configurados corretamente
        if (botaoProximo == null || botaoAnterior == null)
        {
            Debug.LogError("Os botões 'Próximo' ou 'Anterior' não foram atribuídos no Inspector.");
            return;
        }

        if (personagens == null || personagens.Length == 0)
        {
            Debug.LogError("O array 'personagens' está vazio ou não foi atribuído no Inspector.");
            return;
        }

        // Conecte os botões de navegação
        //botaoProximo.onClick.AddListener(ProximoPersonagem);
        //botaoAnterior.onClick.AddListener(PersonagemAnterior);

        AtualizarPersonagens();
    }

    void Update(){
        
        //Realizando a navegação com as teclas
        if(Input.GetKeyDown(KeyCode.RightArrow)){ //Definimos a seta para a direita
            ProximoPersonagem();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            PersonagemAnterior();
        }

        if (Input.GetKeyDown(KeyCode.Return)){
            SelecionarPersonagem();
        }
    }    

    public void ProximoPersonagem()
    {
        //if (personagens.Length == 0) return;

        indexAtual = (indexAtual + 1) % personagens.Length;
        AtualizarPersonagens();
    }

    public void PersonagemAnterior()
    {
        //if (personagens.Length == 0) return;

        indexAtual = (indexAtual - 1 + personagens.Length) % personagens.Length;
        AtualizarPersonagens();
    }

    void AtualizarPersonagens()
    {
        //if (personagens == null || personagens.Length == 0) return;

        // Mostre apenas o personagem atual
        for (int i = 0; i < personagens.Length; i++)
        {
            bool isActive = i == indexAtual;
            personagens[i].SetActive(isActive);

            var imagem = personagens[i].GetComponent<Image>();
            if (imagem != null){
                imagem.color = isActive ? Color.yellow : Color.white;
            }
        }
    }

    public void SelecionarPersonagem()
    {
        Debug.Log("Personagem Selecionado: " + personagens[indexAtual].name);
        // Aqui, você pode salvar a seleção ou iniciar o jogo.
        SceneManager.LoadScene("Fase 1");
    }
}
