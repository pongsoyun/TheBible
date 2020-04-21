# vcam, ThinkingBubble UI List

게임진행에 있어서 잠시 player를 멈추고 CineMachine 처리가 들어가야할 부분들을 타임라인 순으로 기재해둡니다.

타임라인 순으로 기재하면서, UI말풍선 처리도 같이 추가해두었습니다.

## How to read Documentation?

-   collider 처리가 되어있는 오브젝트는 `${objName}`으로 표기합니다.
-   토끼마을 부분까지만 `${objName}`으로 표기해두었고, 나머지는 `cm_flag` 열을 참고해주세요.
-   `cm_`로 시작하는 오브젝트는 모두 camera flag 입니다.
-   `bubble_`로 시작하는 오브젝트는 모두 후 UI 작업시 처리가 들어가야할 말풍선(ThinkingBubble) flag입니다.

더 읽기 편한 링크는 요기-> [스프레드시트 바로가기🔗](https://docs.google.com/spreadsheets/d/1AngKgUCzgy_YrrC_FqnD0_GW8WS3ce1WxyS2qF8st6I/edit#gid=0)

<table>
  <tr>
   <td>구현여부
   </td>
   <td>cinemachine(📹) || ThinkingBubble(💭)
   </td>
   <td>Scene (condition)
   </td>
   <td>cm_flag(spot point) -> <strong>에 도달하면</strong>
   </td>
   <td>Action (branch)
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>게임 Intro. Start 누르면
   </td>
   <td>`cm_IntroScene` -> `cm_IntroSky` -> `cm_Stall`
   </td>
   <td>하늘 ~ 마굿깐까지 보여줌 -> 첫 마굿간 부분을 보여준 후에 주인공이 동그랗게 하늘에서 떨어짐
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭
   </td>
   <td>플레이어가 하늘에서 떨어지면
   </td>
   <td>`bubble_TutorialBtn`
   </td>
   <td>💭 canvas UI button 보여줌(&lt;-, ->, 점프, E key) -> 키 한번씩 누르면 꺼짐
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭
   </td>
   <td>플레이어가 아픈토끼를 보면(${`SickRabbit`}에 닿으면)
   </td>
   <td>`bubble_MiniCure`
   </td>
   <td>💭토끼를 치유해주는 모습 말풍선 5초정도 보여줌
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>토끼마을 입성 후
   </td>
   <td>`cm_TownEntrance` -> `cm_TownBBIng1` -> `cm_TownBBing2` -> `cm_TownEntrance`
   </td>
   <td>괴롭힘 당하는 모습 1${`cm_TownBBing1`} 보여줌 -> 3초 -> 바로 괴롭힘당하는모습 2 ${`cm_TownBBing2`} 보여줌 -> 다시 플레이어가 있던 원점으로 카메라 이동
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>토끼마을을 조금 걷다가, ${`ScreenCollider`}에 닿으면
   </td>
   <td>`cm_TownScreenPlay` -> `cm_TownScreen` -> `cm_TownScreenPlay`
   </td>
   <td>ScreenCollider에 닿으면 영화가 재생되는데, ${cm_TownScreenPlay}위치에 도달하면 -> ${`cm_TownScreen`}으로 이동해 12초간(영화 한사이클) 영화를 비춰줌 -> 12초 후 그중 한두마리는 그런 맹수가 있던가..? 하고 의심 (애니메이션 변경) -> 다시 ${cm_TownScreenPlay}위치로 카메라 돌아옴
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>미니게임1 시작 전
   </td>
   <td>`cm_Game1IntroStart` -> `cm_Game1introDisplay` -> `cm_Game1IntroStart`
   </td>
   <td>힘토끼가 💭 당근! 달라는 뜻 하면서 앞으로 다가오고 → 토끼에 🔥닿으면 토끼 아야 하는 모습을 5초간 보여줌
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>미니게임2 시작 전
   </td>
   <td>`cm_Game2IntroStart` -> `cm_Game2introDisplay` -> `cm_Game2IntroStart`
   </td>
   <td>힘토끼들이 앞으로 다가오고 -> 돌을 던져서 약토끼들 아야 하는 모습 보여줌
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>미니게임2 끝나고,
   </td>
   <td>`cm_CptHouseStart` -> `cm_CptHouseDisplay` -> `cm_CptHouseStart`
   </td>
   <td>짱토끼 집을 한번 보여주고 -> 다시 플레이어가 있던 원점으로 카메라 이동
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭
   </td>
   <td>플레이어가 짱토끼집으로 이동하려고 하면
   </td>
   <td>`bubble_ImagineFriend`
   </td>
   <td>주인공 💭 : 약토끼 힘토끼 사이좋은 모습 상상. (그리고 상상하는 말풍선이 켜지면, 왼쪽에서 작은토끼가 몰래 쫓아오고있는부분 애니메이션 처리)
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭
   </td>
   <td>짱토끼 집으로 들어가서
   </td>
   <td>`bubble_KingCure`
   </td>
   <td>[이부분 안정함. 가장 간단히 생각난 연출로는]💭치유이펙트를 생각함
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>
   </td>
   <td>아픈짱토끼 치유하고나서
   </td>
   <td>
   </td>
   <td>(충격먹는 작은 토끼애니메이션 처리 + 화면에서 왼쪽으로 이동해 사라지게 하기 + 놀란 사운드 처리) ~~카메라 시점이동을 두기에는 안그래도 이 씬 맵이 넓지 않아서 답답할것으로 예상~~
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭
   </td>
   <td>약토끼 사라지는 모습 보여주고 나서 == 아픈짱토끼 치유하고 3초 후 ?
   </td>
   <td>`bubble_SayFriend`
   </td>
   <td>주인공 💭 : 약토끼 힘토끼 사이좋은 모습그림을 말풍선에 띄워보여주고 -> 말풍선 끔 -> 플레이어 다시 메인씬으로 돌아가게 여기서 그냥 씬 꺼도될듯
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>짱토끼 도와주고 돌아와서 왼쪽으로 플레이어 이동
   </td>
   <td>`cm_EndingStart` -> `cm_EndingSmallTalking`
   </td>
   <td>약토끼들이 수근수근잼 하고있는 모습 보여줌
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>💭📹
   </td>
   <td>약토끼 수근수근잼 하는 모습 보여주고 바로 힘토끼마을에서도
   </td>
   <td>`cm_EndingSmallTalking` -> `cm_EndingBigTalking` -> `bubble_PlayerStrong` -> `cm_EndingStart`
   </td>
   <td>수근수근하고있는 모습 보여줌 -> 💭주인공 에너지~(비범한 힘!) 모습을 말풍선으로 보여줌 -> 다시 플레이어가 있던 지점으로 카메라 이동
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>카메라 position은 그대로 있고 좌에서 약토끼 무리, 우에서 큰토끼 무리들이 돌을 던짐
   </td>
   <td>`cm_EndingStart`
   </td>
   <td>카메라 시야 (상-하) 깜빡깜빡 3초간?5번? 함
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>그러다 카메라 시야(상-하)가 서서히 좁아지다가
   </td>
   <td>`cm_EndingStart`
   </td>
   <td>아예 꺼짐
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>아예 꺼진 후 3초 후
   </td>
   <td>`cm_EndingStart`
   </td>
   <td>카메라시야(상-하) 반쯤 열고 약토끼들은 왼쪽, 큰토끼들은 오른쪽으로 걸어가 사라짐
   </td>
  </tr>
  <tr>
   <td>
   </td>
   <td>📹
   </td>
   <td>그대로 토끼들이 화면에서 다 사라지고, 주인공만 죽어있는 모습을 3초정도 보여준 후
   </td>
   <td>`cm_EndingStart` -> `cm_EndingCredit`
   </td>
   <td>엄청 서서히 카메라가 시야를(상-하) 넓히며 하늘로 올라감 -> The end
   </td>
  </tr>
</table>
