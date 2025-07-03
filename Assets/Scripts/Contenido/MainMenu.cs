using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour
{
    public GameObject consultarTeoria;
    public GameObject mainMenu;
    public GameObject descargarGuias;
    public GameObject videosEducativos;
    public GameObject preguntasFrecuentes;

    public GameObject fondoMenu;
    public GameObject fondoTeoria;
    public GameObject fondoDescarga;



    public void OpenConsultarTeoriaPanel()
    {
        mainMenu.SetActive(false);
        consultarTeoria.SetActive(true);
        descargarGuias.SetActive(false);
        videosEducativos.SetActive(false);
        preguntasFrecuentes.SetActive(false);

        fondoMenu.SetActive(false);
        fondoTeoria.SetActive(true);
    }

    public void OpenDescargarGuiasPanel()
    {
        mainMenu.SetActive(false);
        consultarTeoria.SetActive(false);
        descargarGuias.SetActive(true);
        videosEducativos.SetActive(false);
        preguntasFrecuentes.SetActive(false);

        fondoMenu.SetActive(false);
        fondoDescarga.SetActive(true);
    }

    public void OpenVideosEducativosPanel()
    {
        mainMenu.SetActive(false);
        consultarTeoria.SetActive(false);
        descargarGuias.SetActive(false);
        videosEducativos.SetActive(true);
        preguntasFrecuentes.SetActive(false);

        fondoMenu.SetActive(false);
    }

    public void OpenPreguntasFrecuentesPanel()
    {
        mainMenu.SetActive(false);
        consultarTeoria.SetActive(false);
        descargarGuias.SetActive(false);
        videosEducativos.SetActive(false);
        preguntasFrecuentes.SetActive(true);

        fondoMenu.SetActive(false);
        fondoTeoria.SetActive(true);
    }

    public void OpenMainMenuPanel()
    {
        mainMenu.SetActive(true);
        consultarTeoria.SetActive(false);
        descargarGuias.SetActive(false);
        videosEducativos.SetActive(false);
        preguntasFrecuentes.SetActive(false);

        fondoMenu.SetActive(true);
        fondoTeoria.SetActive(false);
        fondoDescarga.SetActive(false);
    }

    public void EnlaceDeBoton(string archivoPdf)
    {
        string rutaLocal = Application.streamingAssetsPath + "/" + archivoPdf;
        Application.OpenURL("file://" + rutaLocal);
    }

    public void EnlaceDeBotonW(string url)
    {
        Application.OpenURL(url);
    }

}
