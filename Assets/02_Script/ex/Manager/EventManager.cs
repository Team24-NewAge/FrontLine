using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventManager : MonoBehaviour
{
    enum eventlist { horses=1, potion, traning ,count};
    eventlist new_event;
    int[] end_event = new int[(int)eventlist.count];



    public Event_Popup eventpopup;
    public GameObject _Event;

    Button btn1,btn2,btn3;
    Text main_text, btn1_text, btn2_text, btn3_text;

    public static EventManager Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

    }
    public void Event() { //이벤트 실행하는 함수
        start_event();
        switch (new_event) {
            case eventlist.horses : {
                    Play_the_horses();

                    end_event[0] = 0;
                    
                }
                break;
            case eventlist.potion: {
                    Potions();

                    end_event[1] = (int)eventlist.potion;

                }
                break;
            case eventlist.traning:
                {
                    Traning();
                    end_event[2] = (int)eventlist.traning;
                }
                break;



        }
    }

    void start_event() {
      new_event = (eventlist)Random.Range(1, (int)eventlist.count);
      
         check_event();
    }

    void check_event() {
        for (int i = 0; i < (int)eventlist.count; i++)
        {
            if (end_event[i] == (int)new_event) {
                start_event();
            }
        }
    }

    public void Play_the_horses() //경마이벤트
    {

        eventpopup.GetComponent<Event_Popup>().button2.gameObject.SetActive(true);

        eventpopup.GetComponent<Event_Popup>().main_text.text = "마을에서 한창 경마경주가 열리고 있다. 심심풀이 삼아 한번 걸어볼까? ";
        eventpopup.GetComponent<Event_Popup>().button_text1.text = "저기 검은말에 걸어볼까\n[골드:250소모]";
        eventpopup.GetComponent<Event_Popup>().button_text2.text = "저 흰말이 잘 달리게 생겼는걸\n[골드:500소모]";
        eventpopup.GetComponent<Event_Popup>().button_text3.text = "시간낭비야. 돌아가자\n[이벤트 포기]";


        Set_EventPoPUP();
        btn1.onClick.AddListener(Play_the_horses_1);
        btn2.onClick.AddListener(Play_the_horses_2);
        btn3.onClick.AddListener(Play_the_horses_3);
    }




void Potions() //포션이벤트
    {

        eventpopup.GetComponent<Event_Popup>().main_text.text = "수상한 마법사가 말을 걸어왔다.\n'이봐 자네, 내가 새로만든 포션을 마셔보는게 어떻겠나?'";
        eventpopup.GetComponent<Event_Popup>().button_text1.text = "뭐, 거절할 필요는 없지\n[랜덤 효과]";
        eventpopup.GetComponent<Event_Popup>().button2.gameObject.SetActive(false);
        eventpopup.GetComponent<Event_Popup>().button_text3.text = "뭘 믿고 그런 수상한걸 먹나?\n[이벤트 포기]";

        Set_EventPoPUP();
        btn1.onClick.AddListener(Potions_1);
        btn3.onClick.AddListener(Potions_2);
    }

    void Traning() //훈련이벤트
    {
        eventpopup.GetComponent<Event_Popup>().button2.gameObject.SetActive(true);

        eventpopup.GetComponent<Event_Popup>().main_text.text = "소문난 훈련교관이 제안을 했다.\n'나에게 훈련을 맡겨준다면 효과는 보장해 드리지'";
        eventpopup.GetComponent<Event_Popup>().button_text1.text = "근력 훈련을 맡긴다\n[유닛의 공격력 증가]";
        eventpopup.GetComponent<Event_Popup>().button_text2.text = "지구력 훈련을 맡긴다\n[유닛의 체력 증가]";
        eventpopup.GetComponent<Event_Popup>().button_text3.text = "대처 훈련을 맡긴다\n[유닛의 방어력 증가]";

        Set_EventPoPUP();
        btn1.onClick.AddListener(Traning_1);
        btn2.onClick.AddListener(Traning_2);
        btn3.onClick.AddListener(Traning_3);
    }



    void Set_EventPoPUP()//이벤트 초기상태 설정 함수
    {
        PopupManager.Instance.ShowEvent_Popup(); // 팝업 클론생성
        _Event = GameObject.Find("Event_popup(Clone)"); // 팝업 클론 오브젝트 등록
        //버튼 1 2 3 할당
        btn1 = _Event.GetComponent<Event_Popup>().button1;
        btn2 = _Event.GetComponent<Event_Popup>().button2;
        btn3 = _Event.GetComponent<Event_Popup>().button3;
        //버튼 텍스트 1 2 3할당
        main_text = _Event.GetComponent<Event_Popup>().main_text;
        btn1_text = _Event.GetComponent<Event_Popup>().button_text1;
        btn2_text = _Event.GetComponent<Event_Popup>().button_text2;
        btn3_text = _Event.GetComponent<Event_Popup>().button_text3;
    }
    void Return() //돌아가기 화면 띄우는 함수
    {
        btn2.gameObject.SetActive(true); // 버튼1 숨김
        btn2_text.text = "돌아간다"; //버튼2 텍스트 변경
        btn2.GetComponentInChildren<RectTransform>().sizeDelta = new Vector2(700, 150); //버튼2 크기 변경
        btn1.gameObject.SetActive(false); // 버튼1 숨김
        btn3.gameObject.SetActive(false); //버튼 3 숨김
        btn2.onClick.RemoveAllListeners(); //버튼2의 모든 리스너 삭제
        btn2.onClick.AddListener(() => { Destroy(_Event); SoundManager.Instance.Lobby_On();}); //버튼2리스너로 창닫기 넣기
    }


    public void Play_the_horses_1()//경마 이벤트 1번선택지
    {
        BarManager.Instance.gold -= 250;

        if (Random.Range(0, 100) < 50)
        {
            main_text.text = "내가 걸었던 검은 말이 우승했다! 500골드를 얻었다!";
            BarManager.Instance.gold += 750;
            Return();//돌아가기 화면
        }
        else {
            main_text.text = "이런... 판돈을 그대로 잃어버렸다..";
            Return();//돌아가기 화면
        }
        BarManager.Instance.gold_text.text = BarManager.Instance.gold.ToString();
        eventpopup.GetComponent<Event_Popup>().button1.onClick.RemoveAllListeners();
    }

    public void Play_the_horses_2()//경마 이벤트 2번선택지
    {
        BarManager.Instance.gold -= 500;

        if (Random.Range(0, 100) < 50)
        {
            print("성공");
            main_text.text = "내가 걸었던 흰 말이 우승했다! 1250골드를 얻었다!";
            BarManager.Instance.gold += 1750;
            Return();//돌아가기 화면
        }
        else
        {
            print("실패");
            main_text.text = "칫, 운 없는 날이군. 돈을 전부 잃었어.";
            Return();//돌아가기 화면
        }
        BarManager.Instance.gold_text.text = BarManager.Instance.gold.ToString();
        eventpopup.GetComponent<Event_Popup>().button1.onClick.RemoveAllListeners();
    }

    public void Play_the_horses_3()//경마 이벤트 3번선택지
    {

            main_text.text = "당신은 경마장을 뒤로하고 집으로 돌아갔다.";
            Return();//돌아가기 화면

    }

    public void Potions_1()//포션 이벤트 1번선택지
    {

        if (Random.Range(0, 100) < 50)
        {
            main_text.text = "영웅의 공격력이 증가한 것 같다";
            Return();//돌아가기 화면
        }
        else
        {
            main_text.text = "속이 안좋아... 공격력이 낮아진 것 같다.";
            Return();//돌아가기 화면
        }
        BarManager.Instance.gold_text.text = BarManager.Instance.gold.ToString();
        eventpopup.GetComponent<Event_Popup>().button1.onClick.RemoveAllListeners();
    }

    public void Potions_2()//포션 이벤트 2번선택지
    {

        main_text.text = "제안을 뒤로하고 집으로 돌아갔다.";
        Return();//돌아가기 화면
    }

    public void Traning_1()//경마 이벤트 1번선택지
    {
        main_text.text = "훈련은 성공적이었다. 모든 유닛의 공격력이 증가했다.";
        Return();//돌아가기 화면
    }

    public void Traning_2()//경마 이벤트 2번선택지
    {
        main_text.text = "소문은 사실이었던 것 같다. 모든 유닛의 체력이 증가했다.";
        Return();//돌아가기 화면
    }

    public void Traning_3()//경마 이벤트 3번선택지
    {

        main_text.text = "후회없는 선택이었다. 모든 유닛의 방어력이 증가했다.";
        Return();//돌아가기 화면

    }

}
