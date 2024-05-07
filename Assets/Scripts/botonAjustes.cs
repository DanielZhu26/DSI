using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class botonAjustes : MonoBehaviour
{
    public void startComponent()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement rootVe = uiDoc.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(rootVe);
        List<VisualElement> lista_ve = builder.ToList();

        VisualElement boton1 = rootVe.Q<Button>("botonMusic");
        VisualElement boton2 = rootVe.Q<Button>("botonOffers");
        VisualElement boton3 = rootVe.Q<Button>("botonSfx");
        VisualElement boton4 = rootVe.Q<Button>("botonChat");
        VisualElement boton5 = rootVe.Q<Button>("botonLanguage");
        VisualElement boton6 = rootVe.Q<Button>("botonFace");
        VisualElement boton7 = rootVe.Q<VisualElement>("BotonCerrar");

        boton7.RegisterCallback<MouseUpEvent>(ev =>
        {
            GetComponent<BarraInferior>().comeBackToMainScreen();
        });

        boton1.RegisterCallback<MouseUpEvent>(ev =>
        {

            VisualElement buttonVe = (ev.target as VisualElement);
            if (buttonVe.style.backgroundColor == Color.red)
            {
                buttonVe.style.backgroundColor = Color.green;
                rootVe.Q<Button>("botonMusic").text = "ON";
            }
            else
            {
                buttonVe.style.backgroundColor = Color.red;
                rootVe.Q<Button>("botonMusic").text = "OFF";
            }
        });

        boton2.RegisterCallback<MouseUpEvent>(ev =>
        {
            VisualElement buttonVe = (ev.target as VisualElement);
            if (buttonVe.style.backgroundColor == Color.red)
            {
                buttonVe.style.backgroundColor = Color.green;
                rootVe.Q<Button>("botonOffers").text = "ON";
            }
            else
            {
                buttonVe.style.backgroundColor = Color.red;
                rootVe.Q<Button>("botonOffers").text = "OFF";
            }
        });

        boton3.RegisterCallback<MouseUpEvent>(ev =>
        {
            VisualElement buttonVe = (ev.target as VisualElement);
            if (buttonVe.style.backgroundColor == Color.red)
            {
                buttonVe.style.backgroundColor = Color.green;
                rootVe.Q<Button>("botonSfx").text = "ON";
            }
            else
            {
                buttonVe.style.backgroundColor = Color.red;
                rootVe.Q<Button>("botonSfx").text = "OFF";
            }
        });

        boton4.RegisterCallback<MouseUpEvent>(ev =>
        {
            VisualElement buttonVe = (ev.target as VisualElement);
            if (buttonVe.style.backgroundColor == Color.red)
            {
                buttonVe.style.backgroundColor = Color.green;
                rootVe.Q<Button>("botonChat").text = "ON";
            }
            else
            {
                buttonVe.style.backgroundColor = Color.red;
                rootVe.Q<Button>("botonChat").text = "OFF";
            }
        });

        boton5.RegisterCallback<MouseUpEvent>(ev =>
        {
            VisualElement buttonVe = (ev.target as VisualElement);
            if (rootVe.Q<Button>("botonLanguage").text == "ENGLISH")
            {

                rootVe.Q<Button>("botonLanguage").text = "SPANISH";
            }
            else
            {

                rootVe.Q<Button>("botonLanguage").text = "ENGLISH";
            }
        });

        boton6.RegisterCallback<MouseUpEvent>(ev =>
        {
            VisualElement buttonVe = (ev.target as VisualElement);
            if (buttonVe.style.backgroundColor == Color.red)
            {
                buttonVe.style.backgroundColor = Color.green;
                rootVe.Q<Button>("botonFace").text = "CONNECTED";
            }
            else
            {
                buttonVe.style.backgroundColor = Color.red;
                rootVe.Q<Button>("botonFace").text = "DISCONNECTED";
            }
        });

    }
}
