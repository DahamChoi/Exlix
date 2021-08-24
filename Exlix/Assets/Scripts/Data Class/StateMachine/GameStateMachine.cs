using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine {
    public enum STATE {
        READY,
        MAIN_MENU,
        CHARACTER_GENERATE_CHARACTER_INFO,
        CHARACTER_GENERATE_DECK,
        CHARACTER_GENERATE_DECK_INFO,
        SELECT_AREA,
        INSIDE_AREA,
        BATTLE,
        ACHEIVE_CARD,
        CHARACTER_MAINTENANCE_MAIN,
        CHARACTER_MAINTENANCE_SKILL,
        CHARACTER_MAINTENANCE_EQUIPMENT,
        CHARACTER_MAINTENANCE_CARD,
        CHARACTER_MAINTENANCE_EQUIPMENT_TREE,
        BOOK

    };

    public enum TRIGGER {
        GAME_START,
        NEW_GAME,
        LOAD_GAME,
        NEWBUTTON,
        INFO_TO_MAIN_MENU,
        INFO_TO_DECK,
        DECK_TO_INFO,
        DECK_TO_GAME,
        DECK_TO_DECK_INFO,
        DECK_INFO_TO_DECK,
        DECK_INFO_TO_MAIN_MENU,
        DECK_TO_MAIN_MENU,
        ENTER_AREA,
        ENTER_BATTLE,
        END_BATTLE,
        END_AREA_EVENT,
        END_MAINTENANCE,
        END_ACHEIVE_CARD,
        MAIN_TO_SKILL,
        SKILLT_TO_MAIN,
        MAIN_TO_EQUIPMENT,
        EQUIPMENT_TO_MAIN,
        EQUIPMENT_TO_TREE,
        TREE_TO_EQUIPMENT,
        MAIN_TO_CARD,
        CARD_TO_MAIN,
        BACK,
        BOOK_TO_MAIN_MENU,
        MAIN_MENU_TO_BOOK
    };

    private Dictionary<STATE, List<KeyValuePair<TRIGGER, STATE>>> Rules =
        new Dictionary<STATE, List<KeyValuePair<TRIGGER, STATE>>>();

    public STATE CurrentState { get; set; }

    public GameStateMachine() {
        // INITAL STATE
        CurrentState = STATE.READY;

        // STATE - READY
        Rules[STATE.READY] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.READY].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.GAME_START, STATE.MAIN_MENU)
        );

        // 메인메뉴
        Rules[STATE.MAIN_MENU] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.MAIN_MENU].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.NEW_GAME, STATE.CHARACTER_GENERATE_CHARACTER_INFO));
        Rules[STATE.MAIN_MENU].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.LOAD_GAME, STATE.SELECT_AREA));
        Rules[STATE.MAIN_MENU].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.MAIN_MENU_TO_BOOK, STATE.BOOK));

        // 캐릭터 생성화면 캐릭터 정보
        Rules[STATE.CHARACTER_GENERATE_CHARACTER_INFO] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_GENERATE_CHARACTER_INFO].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.INFO_TO_MAIN_MENU, STATE.MAIN_MENU));
        Rules[STATE.CHARACTER_GENERATE_CHARACTER_INFO].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.INFO_TO_DECK, STATE.CHARACTER_GENERATE_DECK));

        // 캐릭터 덱 선택
        Rules[STATE.CHARACTER_GENERATE_DECK] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_GENERATE_DECK].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_TO_GAME, STATE.SELECT_AREA));
        Rules[STATE.CHARACTER_GENERATE_DECK].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_TO_DECK_INFO, STATE.CHARACTER_GENERATE_DECK_INFO));
        Rules[STATE.CHARACTER_GENERATE_DECK].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_TO_INFO, STATE.CHARACTER_GENERATE_CHARACTER_INFO));
        Rules[STATE.CHARACTER_GENERATE_DECK].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_TO_MAIN_MENU, STATE.MAIN_MENU));

        // 캐릭터 생성 덱 보기
        Rules[STATE.CHARACTER_GENERATE_DECK_INFO] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_GENERATE_DECK_INFO].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_INFO_TO_DECK, STATE.CHARACTER_GENERATE_DECK));
        Rules[STATE.CHARACTER_GENERATE_DECK_INFO].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.DECK_INFO_TO_MAIN_MENU, STATE.MAIN_MENU));

        // 구역 선택
        Rules[STATE.SELECT_AREA] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.SELECT_AREA].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.ENTER_AREA, STATE.INSIDE_AREA));

        // 구역 내부
        Rules[STATE.INSIDE_AREA] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.INSIDE_AREA].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.ENTER_BATTLE, STATE.BATTLE));
        Rules[STATE.INSIDE_AREA].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.END_AREA_EVENT, STATE.ACHEIVE_CARD));

        // BATTLE
        Rules[STATE.BATTLE] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.BATTLE].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.END_BATTLE, STATE.INSIDE_AREA));

        // 캐릭터 카드 획득
        Rules[STATE.ACHEIVE_CARD] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.ACHEIVE_CARD].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.END_ACHEIVE_CARD, STATE.CHARACTER_MAINTENANCE_MAIN));

        // 캐릭터 정비
        Rules[STATE.CHARACTER_MAINTENANCE_MAIN] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_MAINTENANCE_MAIN].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.MAIN_TO_SKILL, STATE.CHARACTER_MAINTENANCE_SKILL));
        Rules[STATE.CHARACTER_MAINTENANCE_MAIN].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.MAIN_TO_EQUIPMENT, STATE.CHARACTER_MAINTENANCE_EQUIPMENT));
        Rules[STATE.CHARACTER_MAINTENANCE_MAIN].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.MAIN_TO_CARD, STATE.CHARACTER_MAINTENANCE_CARD));
        Rules[STATE.CHARACTER_MAINTENANCE_MAIN].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.END_MAINTENANCE, STATE.INSIDE_AREA));

        // 캐릭터 스킬 정비
        Rules[STATE.CHARACTER_MAINTENANCE_SKILL] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_MAINTENANCE_SKILL].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.SKILLT_TO_MAIN, STATE.CHARACTER_MAINTENANCE_MAIN));

        // 캐릭터 장비 정비
        Rules[STATE.CHARACTER_MAINTENANCE_EQUIPMENT] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_MAINTENANCE_EQUIPMENT].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.EQUIPMENT_TO_MAIN, STATE.CHARACTER_MAINTENANCE_MAIN));
        Rules[STATE.CHARACTER_MAINTENANCE_EQUIPMENT].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.EQUIPMENT_TO_TREE, STATE.CHARACTER_MAINTENANCE_EQUIPMENT_TREE));

        // 캐릭터 장비 트리
        Rules[STATE.CHARACTER_MAINTENANCE_EQUIPMENT_TREE] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_MAINTENANCE_EQUIPMENT_TREE].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.TREE_TO_EQUIPMENT, STATE.CHARACTER_MAINTENANCE_EQUIPMENT));

        // 캐릭터 덱 정비
        Rules[STATE.CHARACTER_MAINTENANCE_CARD] = new List<KeyValuePair<TRIGGER, STATE>>();
        Rules[STATE.CHARACTER_MAINTENANCE_CARD].Add(
            new KeyValuePair<TRIGGER, STATE>(TRIGGER.CARD_TO_MAIN, STATE.CHARACTER_MAINTENANCE_MAIN));
    }

    public void ProcessEvent(TRIGGER trigger) {
        if (TRIGGER.BACK == trigger) {
            if (STATE.CHARACTER_GENERATE_CHARACTER_INFO == CurrentState ||
                STATE.CHARACTER_GENERATE_DECK == CurrentState ||
                STATE.BOOK == CurrentState) {
                CurrentState = STATE.MAIN_MENU;
            } else if (STATE.CHARACTER_GENERATE_DECK_INFO == CurrentState) {
                CurrentState = STATE.CHARACTER_GENERATE_DECK;
            } else if (STATE.CHARACTER_MAINTENANCE_SKILL == CurrentState ||
                  STATE.CHARACTER_MAINTENANCE_EQUIPMENT == CurrentState ||
                  STATE.CHARACTER_MAINTENANCE_CARD == CurrentState) {
                CurrentState = STATE.CHARACTER_MAINTENANCE_MAIN;
            } else if (STATE.CHARACTER_MAINTENANCE_EQUIPMENT_TREE == CurrentState) {
                CurrentState = STATE.CHARACTER_MAINTENANCE_EQUIPMENT;
            }

            return;
        }

        foreach (var it in Rules[CurrentState]) {
            if (it.Key == trigger) {
                CurrentState = it.Value;
                return;
            }
        }
    }
}
