using UnityEngine;
using UnityEngine.UI;
public class CharacterGenerate_Deck_Info_UIController : MonoBehaviour {

    [SerializeField] Text CardExplain;
    [SerializeField] Text CardMana;
    [SerializeField] Text CardTitle;
    [SerializeField] Text CardFaction;

    public void updateCardExplain(CardDTO card) {
        CardExplain.text = card.Explanation;
        CardMana.text = card.Mana.ToString();
        CardTitle.text = card.Title;
        CardFaction.text = card.Property;
    }
}
