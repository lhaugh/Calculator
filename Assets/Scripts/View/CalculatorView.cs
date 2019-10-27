using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
        [SerializeField]
        private Button button0 = null;
        [SerializeField]
        private Button button1 = null;
        [SerializeField]
        private Button button2 = null;
        [SerializeField]
        private Button button3 = null;
        [SerializeField]
        private Button button4 = null;
        [SerializeField]
        private Button button5 = null;
        [SerializeField]
        private Button button6 = null;
        [SerializeField]
        private Button button7 = null;
        [SerializeField]
        private Button button8 = null;
        [SerializeField]
        private Button button9 = null;
        [SerializeField]
        private Button buttonDecimal = null;
        [SerializeField]
        private Button buttonMultiply = null;
        [SerializeField]
        private Button buttonDivide = null;
        [SerializeField]
        private Button buttonAdd = null;
        [SerializeField]
        private Button buttonSubtract = null;
        [SerializeField]
        private Button buttonOpenBracket = null;
        [SerializeField]
        private Button buttonCloseBracket = null;
        [SerializeField]
        private Button buttonEquals = null;
        [SerializeField]
        private Button buttonClear = null;
        [SerializeField]
        private TMP_InputField inputField = null;
    

        public string DisplayContents 
        { 
            get { return this.inputField.text; }
            set { this.inputField.text = value; }
        }

        public event Action MulitplyPressed;
        public event Action DividePressed;
        public event Action AddPressed;
        public event Action SubtractPressed;
        public event Action EqualsPressed;
        public event Action<int> NumberPressed;
        public event Action DecimalPressed;
        public event Action ClearPressed;
        public event Action OpenBracketPressed;
        public event Action CloseBracketPressed;


        private void Start()
        {
            this.button0.onClick.AddListener(this.OnButton0Pressed);
            this.button1.onClick.AddListener(this.OnButton1Pressed);
            this.button2.onClick.AddListener(this.OnButton2Pressed);
            this.button3.onClick.AddListener(this.OnButton3Pressed);
            this.button4.onClick.AddListener(this.OnButton4Pressed);
            this.button5.onClick.AddListener(this.OnButton5Pressed);
            this.button6.onClick.AddListener(this.OnButton6Pressed);
            this.button7.onClick.AddListener(this.OnButton7Pressed);
            this.button8.onClick.AddListener(this.OnButton8Pressed);
            this.button9.onClick.AddListener(this.OnButton9Pressed);
            this.buttonDecimal.onClick.AddListener(this.OnButtonDecimalPressed);

            this.buttonMultiply.onClick.AddListener(this.OnButtonMultiplyPressed);
            this.buttonDivide.onClick.AddListener(this.OnButtonDividePressed);
            this.buttonAdd.onClick.AddListener(this.OnButtonAddPressed);
            this.buttonSubtract.onClick.AddListener(this.OnButtonSubtractPressed);
            this.buttonOpenBracket.onClick.AddListener(this.OnButtonOpenBracketPressed);
            this.buttonCloseBracket.onClick.AddListener(this.OnButtonCloseBracketPressed);
            this.buttonEquals.onClick.AddListener(this.OnButtonEqualsPressed);
            this.buttonClear.onClick.AddListener(this.OnButtonClearPressed);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return)) {
                this.EqualsPressed?.Invoke();
            }
        }

        private void OnButton0Pressed()
        {
            this.NumberPressed?.Invoke(0);
        }

        private void OnButton1Pressed()
        {
            this.NumberPressed?.Invoke(1);
        }

        private void OnButton2Pressed()
        {
            this.NumberPressed?.Invoke(2);
        }

        private void OnButton3Pressed()
        {
            this.NumberPressed?.Invoke(3);
        }

        private void OnButton4Pressed()
        {
            this.NumberPressed?.Invoke(4);
        }

        private void OnButton5Pressed()
        {
            this.NumberPressed?.Invoke(5);
        }

        private void OnButton6Pressed()
        {
            this.NumberPressed?.Invoke(6);
        }

        private void OnButton7Pressed()
        {
            this.NumberPressed?.Invoke(7);
        }

        private void OnButton8Pressed()
        {
            this.NumberPressed?.Invoke(8);
        }

        private void OnButton9Pressed()
        {
            this.NumberPressed?.Invoke(9);
        }

        private void OnButtonDecimalPressed()
        {
            this.DecimalPressed?.Invoke();
        }

        private void OnButtonMultiplyPressed()
        {
            this.MulitplyPressed?.Invoke();
        }

        private void OnButtonDividePressed()
        {
            this.DividePressed?.Invoke();
        }

        private void OnButtonAddPressed()
        {
            this.AddPressed?.Invoke();
        }

        private void OnButtonSubtractPressed()
        {
            this.SubtractPressed?.Invoke();
        }

        private void OnButtonEqualsPressed()
        {
            this.EqualsPressed?.Invoke();
        }

        private void OnButtonClearPressed()
        {
            this.ClearPressed?.Invoke();
        }

        private void OnButtonOpenBracketPressed()
        {
            this.OpenBracketPressed?.Invoke();
        }

        private void OnButtonCloseBracketPressed()
        {
            this.CloseBracketPressed?.Invoke();
        }
    }
}
