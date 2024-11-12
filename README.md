# Modal Popup Bootstrap style 
<!--![배지 또는 로고 이미지 (선택사항)](링크)-->
<!--프로젝트에 대한 간단한 설명을 여기에 작성합니다.-->
Bootstrap 스타일의 모달 팝업창입니다.
![ModalPopupBootstrapSytle](https://github.com/user-attachments/assets/749452ff-0aca-4378-9d02-ff513cff9ef2)


## 목차
- [Modal Popup Bootstrap style](#modal-popup-bootstrap-style)
  - [목차](#목차)
  - [소개](#소개)
  - [사용법](#사용법)
  - [참조링크](#참조링크)
<!--- [기여](#기여)
- [라이선스](#라이선스)
- [문의](#문의)
-->
## 소개
<!--프로젝트에 대한 자세한 설명을 여기에 작성합니다.  -->
- **개발환경** : C#, .Net Framework 4.7.2, Visual Studio 2019

- **주요기능** : 
   
   1. 윈도우 또는 소유 폼을 설정하여 중앙에 Modal Popup 오픈 가능
   2. 다른 폼을 Modal Popup을 통해서 오픈 가능
   3. BaseModal을 상속받아 폼생성 가능
## 사용법
* 기본 모달 오픈

  ```
  //윈도우를 기준으로 모달 오픈
  Modal modal = new Modal();
  modal.ShowDialog();

  //소유폼을 기준으로 모달 오픈
  Modal modal = new Modal(this);
  modal.ShowDialog();

  //모달안에 다른 폼을 표시
  popupTest pop = new popupTest();
  Modal modal = new Modal(pop, this);
  modal.ShowDialog();
  ```

* 모달상속받기
  
  ```
      public partial class PopupByBaseModal : BaseModal
    {
        public PopupByBaseModal()
        {
            InitializeComponent();
            //this.Opacity = 0; //0설정이 되어야 애니메이션 처리
        }
    }
  ```


## 참조링크
https://youtu.be/8vavpfU0yKQ?si=P_EmclLqOGclW9NV
