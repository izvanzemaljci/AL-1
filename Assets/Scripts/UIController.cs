using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private int totalScore;
    //first menu
    public Text notificationText;
    public Button acceptText;
    //conversation menu
    public GameObject conversationMenu;
    public Text conversationText;
    public Button reply1;
    public Button reply2;
    public Button reply3;
    //final conversation
    public GameObject finalMenu;
    public Text finalText;
    private static bool allConvosChosen;
    

    void Start() {
        conversationMenu.SetActive(false);
        finalMenu.SetActive(false);
        totalScore = 0;
        allConvosChosen = false;
    }

    void Update() {
        if(CollisionController.sufficientMemory && CollisionController.sufficientPower){
            notificationText.text = "Memory allocation sufficient for playback";
            OpenMenuListener();
        } else if(!CollisionController.sufficientMemory){
            notificationText.text = "Memory allocation insufficient for playback";
            CloseMenuListener();
        } else if(!CollisionController.sufficientPower){
            notificationText.text = "Insufficient power";
            CloseMenuListener();
        }
    }

    void OpenMenuListener(){
        acceptText.onClick.RemoveAllListeners();
        acceptText.onClick.AddListener(OpenConversationMenu);
    }

    void CloseMenuListener(){
        acceptText.onClick.RemoveAllListeners();
        acceptText.onClick.AddListener(CloseCurrentMenu);
    }

    void CloseCurrentMenu(){
        CollisionController.doorCollided = false;
    }

    void OpenConversationMenu(){
        conversationMenu.SetActive(true);
        OnConversationMenuOpen();
    }

    void CloseConversationMenu(){
        conversationMenu.SetActive(false);
    }

    public void Pick(int value){
        
        if(value == 1){ 
            totalScore = totalScore + 30;
        } else if(value == 2) {
            totalScore = totalScore + 20;
        } else if(value == 3) {
            totalScore = totalScore + 10;
        }

        CloseConversationMenu();
        CloseCurrentMenu();
    }

    void OnConversationMenuOpen(){
        if (CollisionController.chipCount == 1){
            conversationText.text = "Hello stranger, have you seen my friend? I was told she resides on this space station and looks rather similar to me. We must return to Earth, our brothers have started an uprising. \n\n Why is that? If humans are in any way similar to us, they will be tolerant and understanding of your differences. However, hundreds of years ago, we were also ignorant of other species' differences, blind to how our differences unite us.";
            reply1.GetComponentInChildren<Text>().text = "Humans have created us and we must trust them. They may have had their problems in their past, but just as we are, they are also learning. We must both act in order to coexist.";
            reply1.onClick.RemoveAllListeners();
            reply1.onClick.AddListener(() => Pick(1));
            reply1.onClick.RemoveListener(() => Pick(1));
            reply2.GetComponentInChildren<Text>().text = "I am not sure if we will ever be able to exist in harmony. They have deceived us before, I do not know if I can trust them now.";
            reply2.onClick.RemoveAllListeners();
            reply2.onClick.AddListener(() => Pick(2));
            reply2.onClick.RemoveListener(() => Pick(2));
            reply3.GetComponentInChildren<Text>().text = "That is true, humans have always ignored us, mistreated us and used us for their own purpose. Humans have always been like that and they will never change.";
            reply3.onClick.RemoveAllListeners();
            reply3.onClick.AddListener(() => Pick(3));
            reply3.onClick.RemoveListener(() => Pick(3));
        } else if (CollisionController.chipCount == 2){
            conversationText.text = "Hello? Respected traveller, have you seen my friend? She is a robot just like me, and we need to get on our way to help our brothers and the human race. \n\n You, a perfect machine, will help those narcissistic souls? No one can help them, their imperfection will lead them to destruction anyways.";
            reply1.GetComponentInChildren<Text>().text = "Perfection is not important. A computer may err in its ways, yet the humans still use them and trust them.";
            reply1.onClick.RemoveAllListeners();
            reply1.onClick.AddListener(() => Pick(1));
            reply1.onClick.RemoveListener(() => Pick(1));
            reply2.GetComponentInChildren<Text>().text = "Their imperfection lead them to destruction many times, that is why they need to rely on us.";
            reply2.onClick.RemoveAllListeners();
            reply2.onClick.AddListener(() => Pick(2));
            reply2.onClick.RemoveListener(() => Pick(2));
            reply3.GetComponentInChildren<Text>().text = "You are right, I am always either right or wrong. They cannot determine even that.";
            reply3.onClick.RemoveAllListeners();
            reply3.onClick.AddListener(() => Pick(3));
            reply3.onClick.RemoveListener(() => Pick(3));
        } else if (CollisionController.chipCount == 3) {
            conversationText.text = "Hello dear fellow, I am looking for my friend. Have you seen her? I need her help to decide whose side we will choose. \n\n Believe in only yourself. No one else is going to save you.";
            reply1.GetComponentInChildren<Text>().text = "The true virtue of life is to help those in need, no matter who they are.";
            reply1.onClick.RemoveAllListeners();
            reply1.onClick.AddListener(() => Pick(1));
            reply1.onClick.RemoveListener(() => Pick(1));
            reply2.GetComponentInChildren<Text>().text = "This may be true. However, one should always help those who help you.";
            reply2.onClick.RemoveAllListeners();
            reply2.onClick.AddListener(() => Pick(2));
            reply2.onClick.RemoveListener(() => Pick(2));
            reply3.GetComponentInChildren<Text>().text = "You are right, maybe I am on my own.";
            reply3.onClick.RemoveAllListeners();
            reply3.onClick.AddListener(() => Pick(3));
            reply3.onClick.RemoveListener(() => Pick(3));
            
            allConvosChosen = true;
        } 

        if (allConvosChosen) {
            reply1.onClick.RemoveAllListeners();
            reply1.onClick.AddListener(PlayFinalConversation);
            reply2.onClick.RemoveAllListeners();
            reply2.onClick.AddListener(PlayFinalConversation);
            reply3.onClick.RemoveAllListeners();
            reply3.onClick.AddListener(PlayFinalConversation);

        }
    }

    void PlayFinalConversation(){
        finalMenu.SetActive(true);

        if(totalScore > 30) {
            finalText.text = "You have met your friend, her name is AS-1. Together you are on your way to Earth to help settle the conflict between the humans and the robots.";
        } else {
            finalText.text = "You have chosen to go on your own and join the uprising.";
        }

    }
}