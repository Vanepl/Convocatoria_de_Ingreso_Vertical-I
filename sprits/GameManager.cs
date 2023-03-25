using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public float velocidad = 2;
    public GameObject col;
    public GameObject hongo1;
    public GameObject puya1;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    // Start is called before the first frame update
    void Start()
    {
        //Creacion de mapa
        for (int i=0; i<21; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -2), Quaternion.identity));
        }

        //Creacion de Obstaculos
        obstaculos.Add(Instantiate(hongo1, new Vector2(14, -2), Quaternion.identity));
        obstaculos.Add(Instantiate(puya1, new Vector2(18, -2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if(start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }

        if (start == true && gameOver == true)
        {

            menuGameOver.SetActive(true);        

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if (start == true && gameOver == false)
        {

            menuPrincipal.SetActive(false);
            
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.050f, 0) * Time.deltaTime;

            // Mover piso
            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }

                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //mover Obstaculos
            for (int i = 0; i < obstaculos.Count; i++)
            {
                if (obstaculos[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(11, 20);
                    obstaculos[i].transform.position = new Vector3(randomObs, -2, 0);
                }

                obstaculos[i].transform.position = obstaculos[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
