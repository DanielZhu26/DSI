using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.IO;
using UnityEditor;
using static JSONHelper;

public class CardSelectionFun : MonoBehaviour
{
    VisualElement selectCardInfo;

    VisualElement botonGuardar;

    VisualElement CardSelection;

    VisualElement desk;

    //private void OnEnable()
    //{
    //    VisualElement root = GetComponent<UIDocument>().rootVisualElement;

    //    desk = root.Q("Desk");

    //    Debug.Log(desk);

    //    botonGuardar = root.Q<Button>("BotonGuardar");

    //    desk.RegisterCallback<ClickEvent>(selectionCard);

    //    CardSelection = root.Q("CardSelection");

    //    List<VisualElement> list_ve_h = new();
    //    list_ve_h.AddRange(CardSelection.Children().ToList());


    //    list_ve_h.ForEach(elem => {

    //        elem.RegisterCallback<ClickEvent, VisualElement>(ChangeCard, elem);

    //    });

    //    botonGuardar.RegisterCallback<ClickEvent>(guardarInfo);

    //    InicializarCards();

    //}

    public void startComponent()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        desk = root.Q("Desk");

        Debug.Log(desk);

        botonGuardar = root.Q<Button>("BotonGuardar");

        desk.RegisterCallback<ClickEvent>(selectionCard);

        CardSelection = root.Q("CardSelection");

        List<VisualElement> list_ve_h = new();
        list_ve_h.AddRange(CardSelection.Children().ToList());


        list_ve_h.ForEach(elem => {

            elem.RegisterCallback<ClickEvent, VisualElement>(ChangeCard, elem);

        });

        botonGuardar.RegisterCallback<ClickEvent>(guardarInfo);

        InicializarCards();

    }

    void InicializarCards()
    {
        List<InfoCard> datos = new List<InfoCard>();

        string path = Path.Combine(Application.persistentDataPath, "desk_info");
        Debug.Log(path);

        if(File.Exists(path))
        {
            string individuosInfo = File.ReadAllText(path);

            datos = JSONHelperInfoCard.FromJSON<InfoCard>(individuosInfo);

            int contador = 0;

            datos.ForEach(elem => {

                VisualElement deskImage = desk[contador].Q<VisualElement>("Card");

                Label elixirLabel = desk[contador].Q<Label>("amount");

                deskImage.style.backgroundImage = Resources.Load<Texture2D>(Path.GetFileNameWithoutExtension(elem.image));

                Debug.Log(elem.image);
                Debug.Log(Resources.Load<Texture2D>(Path.GetFileNameWithoutExtension(elem.image)));

                elixirLabel.text = elem.elixir;

                contador++;
            });
        } 
        
    }


    void guardarInfo(ClickEvent evt)
    {

        List<InfoCard> list_infoCard = new List<InfoCard>();

        List<VisualElement> list_desk = new();
        list_desk.AddRange(desk.Children().ToList());


        list_desk.ForEach(elem => {

            VisualElement elemImage = elem.Q<VisualElement>("Card");

            Label elixirLabel = elem.Q<Label>("amount");

            string pathTexture = (string)AssetDatabase.GetAssetPath(elemImage.resolvedStyle.backgroundImage.texture);

            list_infoCard.Add(new InfoCard(elixirLabel.text, pathTexture));     

        });

        string listaToJson = JSONHelperInfoCard.ToJson(list_infoCard, true);

        string path = Path.Combine(Application.persistentDataPath, "desk_info");

        File.WriteAllText(path, listaToJson);

        Debug.Log(path);

    }

    void selectionCard(ClickEvent evt)
    {
        VisualElement card = evt.target as VisualElement;

        selectCardInfo = card;

        card_borde_negro();
        card_borde_blanco(card);

    }

    void ChangeCard(ClickEvent evt, VisualElement selected)
    {

        bool repeatCard = false;

        VisualElement imageSelecction = selected.Q<VisualElement>("Card");

        List<VisualElement> list_desk = new();
        list_desk.AddRange(desk.Children().ToList());


        list_desk.ForEach(elem => {

            VisualElement elemImage = elem.Q<VisualElement>("Card");

            if (elemImage.resolvedStyle.backgroundImage == imageSelecction.resolvedStyle.backgroundImage)
            {
                repeatCard = true;
            }

        });


        if (selectCardInfo != null && !repeatCard)
        {

            Label elixirLabel = selected.Q<Label>("amount");

            Label elixirLabelDesk = selectCardInfo.Q<Label>("amount");

            VisualElement imageDesk = selectCardInfo.Q<VisualElement>("Card");

            elixirLabelDesk.text = elixirLabel.text;

            imageDesk.style.backgroundImage = imageSelecction.resolvedStyle.backgroundImage;

            Debug.Log(imageSelecction.resolvedStyle.backgroundImage.texture);

        }
        

    }

    void card_borde_negro()
    { 

        List<VisualElement> list_card = desk.Children().ToList();
        list_card.ForEach(elem =>
        {

            VisualElement card = elem.Q("Card");

            card.style.borderBottomColor = Color.black;
            card.style.borderRightColor = Color.black;
            card.style.borderTopColor = Color.black;
            card.style.borderLeftColor = Color.black;

        });
    }

    void card_borde_blanco(VisualElement card)
    {

        VisualElement carta = card.Q("Card");

        carta.style.borderBottomColor = Color.yellow;
        carta.style.borderRightColor = Color.yellow;
        carta.style.borderTopColor = Color.yellow;
        carta.style.borderLeftColor = Color.yellow;

    }



}
