using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

public class YarnCommands : MonoBehaviour
{
    #region Variables
        private Vector3 position;

        [Header("General")]
        [SerializeField] DialogueRunner dialogueRunner;
        [SerializeField] TextMeshProUGUI speakerName;
        [SerializeField] Image dialoguePanel;
        #region Assets
            [Header("Assets")]
            [SerializeField] Sprite basePanel;
            [SerializeField] Sprite izzyPanel;
            [SerializeField] Sprite housePanel;
            [SerializeField] Sprite skyPanel;
            [SerializeField] Sprite scarletPanel;
            [SerializeField] Sprite charPanel;
        #endregion
        #region Game Objects
            [Header("Game Objects")]
            [SerializeField] GameObject izzy;
            [SerializeField] GameObject scarlet;
            [SerializeField] GameObject sky;
            [SerializeField] GameObject house;
        #endregion
        #region Positions
            [Header("Position Reference")]
            [SerializeField] GameObject pos1; //Far Left
            [SerializeField] GameObject pos2; //Left
            [SerializeField] GameObject pos3; //Right
            [SerializeField] GameObject pos4; //Far Right
            [SerializeField] GameObject pos5; //Center
            [SerializeField] GameObject pos0; //Offscreen
        #endregion
    #endregion

    public void Awake()
    {
        dialogueRunner.AddCommandHandler(
            "setSpeaker",   //name of command
            SetSpeaker      //method to run
        );
        dialogueRunner.AddCommandHandler(
            "setStage",
            SetStage
        );
        dialogueRunner.AddCommandHandler(
            "setPos",
            SetPos
        );

    }
    public void SetSpeaker(string[] name){
        switch (name[0]){
            case "none":
                speakerName.text = "";
                dialoguePanel.sprite = basePanel;
                break;
            case "house":
                speakerName.text = "The House";
                dialoguePanel.sprite = housePanel;
                break;
            case "House":
                speakerName.text = "The House";
                dialoguePanel.sprite = housePanel;
                break;
            case "zz":
                speakerName.text = "Izzy";
                dialoguePanel.sprite = izzyPanel;
                break;
            case "Izzy":
                speakerName.text = "Izzy";
                dialoguePanel.sprite = izzyPanel;
                break;
            case "izzy":
                speakerName.text = "Izzy";
                dialoguePanel.sprite = izzyPanel;
                break;
            case "sky":
                speakerName.text = "Sky";
                dialoguePanel.sprite = skyPanel;
                break;
            case "Sky":
                speakerName.text = "Sky";
                dialoguePanel.sprite = skyPanel;
                break;
            case "scar":
                speakerName.text = "Scarlet";
                dialoguePanel.sprite = scarletPanel;
                break;
            case "Scar":
                speakerName.text = "Scarlet";
                dialoguePanel.sprite = scarletPanel;
                break;
            default:
                speakerName.text = name[0];
                dialoguePanel.sprite = charPanel;
                break;
        }
    }
    public void SetStage(string[] stage){
        switch (stage[0]){
            case "dice":
                izzy.transform.position = pos0.transform.position;
                scarlet.transform.position = pos1.transform.position;
                sky.transform.position = pos4.transform.position;
                house.transform.position = pos0.transform.position;
                break;
            case "izzy":
                izzy.transform.position = pos5.transform.position;
                scarlet.transform.position = pos0.transform.position;
                sky.transform.position = pos0.transform.position;
                house.transform.position = pos0.transform.position;
                break;
            case "clear":
                izzy.transform.position = pos0.transform.position;
                scarlet.transform.position = pos0.transform.position;
                sky.transform.position = pos0.transform.position;
                house.transform.position = pos0.transform.position;
                break;
            default:
                izzy.transform.position = pos0.transform.position;
                scarlet.transform.position = pos0.transform.position;
                sky.transform.position = pos0.transform.position;
                house.transform.position = pos0.transform.position;
                break;

        }
    }
    public void SetPos(string[] parameters){
        switch(parameters[1]){
            case "pos0":
                position = pos0.transform.position;
                break;
            case "pos1":
                position = pos1.transform.position;
                break;
            case "pos2":
                position = pos2.transform.position;
                break;
            case "pos3":
                position = pos3.transform.position;
                break;
            case "pos4":
                position = pos4.transform.position;
                break;
            case "pos5":
                position = pos5.transform.position;
                break;
            default:
                position = pos0.transform.position;
                break;
        }
        switch(parameters[0]){
            case "zz":
                izzy.transform.position = position;
                break;
            case "izzy":
                izzy.transform.position = position;
                break;
            case "Izzy":
                izzy.transform.position = position;
                break;
            case "scarlet":
                scarlet.transform.position = position;
                break;
            case "sky":
                sky.transform.position = position;
                break;
            case "house":
                house.transform.position = position;
                break;
        }
    }
}
