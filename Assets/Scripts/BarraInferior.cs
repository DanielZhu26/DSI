using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BarraInferior : MonoBehaviour
{
    [SerializeField] VisualTreeAsset uiDoc1;
    [SerializeField] VisualTreeAsset uiDoc2;
    [SerializeField] VisualTreeAsset uiDoc3;
    [SerializeField] VisualTreeAsset uiDoc4;
    [SerializeField] VisualTreeAsset uiDoc5;
    [SerializeField] VisualTreeAsset uiDoc6;

    public void comeBackToMainScreen()
    {
        GetComponent<UIDocument>().visualTreeAsset = uiDoc3;
        startComponent();
    }

    void startComponent()
    {
        UIDocument uiDoc = GetComponent<UIDocument>();
        VisualElement rootVe = uiDoc.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(rootVe);
        List<VisualElement> lista_ve = builder.ToList();

        VisualElement boton1 = rootVe.Q<Button>("Boton1");
        VisualElement boton2 = rootVe.Q<Button>("Boton2");
        VisualElement boton3 = rootVe.Q<Button>("Boton3");
        VisualElement boton4 = rootVe.Q<Button>("Boton4");
        VisualElement boton5 = rootVe.Q<Button>("Boton5");
        VisualElement boton6 = new VisualElement();
        if (GetComponent<UIDocument>().visualTreeAsset == uiDoc3)
            boton6 = rootVe.Q<Button>("Boton6");

        boton1.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("boton1");
            GetComponent<UIDocument>().visualTreeAsset = uiDoc1;
            startComponent();
        });
        boton2.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("boton2");
            GetComponent<UIDocument>().visualTreeAsset = uiDoc2;
            startComponent();
            GetComponent<CardSelectionFun>().startComponent();
        });
        boton3.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("boton3");
            GetComponent<UIDocument>().visualTreeAsset = uiDoc3;
            startComponent();
        });
        boton4.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("boton4");
            GetComponent<UIDocument>().visualTreeAsset = uiDoc4;
            startComponent();
        });
        boton5.RegisterCallback<MouseUpEvent>(ev =>
        {
            Debug.Log("boton5");
            GetComponent<UIDocument>().visualTreeAsset = uiDoc5;
            startComponent();
        });

        if (GetComponent<UIDocument>().visualTreeAsset == uiDoc3)
        {
            boton6.RegisterCallback<MouseUpEvent>(ev =>
            {
                Debug.Log("boton6");
                GetComponent<UIDocument>().visualTreeAsset = uiDoc6;
                GetComponent<botonAjustes>().startComponent();
            });
        }
    }

    private void OnEnable()
    {
        startComponent();
    }
}
