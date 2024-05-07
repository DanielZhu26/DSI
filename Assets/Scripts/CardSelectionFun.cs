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

    string imageCard;

    VisualElement CardSelection;

    VisualElement desk;

    List<InfoCard> list_infoCard = new List<InfoCard>();
    private void OnEnable()
    {

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        desk = root.Q("Desk");

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
        list_infoCard.ForEach(elem =>
        {

            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("Card");
            VisualElement cardPlantilla = plantilla.Instantiate();

            desk.Add(cardPlantilla);
            card_borde_negro();
            card_borde_blanco(cardPlantilla);

            InfoCard cardInfo = new InfoCard(elem.elixir, elem.image);
            Card tarjeta = new Card(cardPlantilla, cardInfo);
            selectCardInfo = cardPlantilla;
        });
    }


    void guardarInfo(ClickEvent evt)
    {

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

            imageDesk.style.backgroundImage = imageSelecction.resolvedStyle.backgroundImage.texture;

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
