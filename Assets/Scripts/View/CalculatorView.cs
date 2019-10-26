using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Calculator.View
{
    public class CalculatorView : MonoBehaviour, ICalculatorView
    {
#pragma warning disable 0649

        [SerializeField]
        private Button button0;
        [SerializeField]
        private Button button1;
        [SerializeField]
        private Button button2;
        [SerializeField]
        private Button button3;
        [SerializeField]
        private Button button4;
        [SerializeField]
        private Button button5;
        [SerializeField]
        private Button button6;
        [SerializeField]
        private Button button7;
        [SerializeField]
        private Button button8;
        [SerializeField]
        private Button button9;
        [SerializeField]
        private Button buttonDecimal;
        [SerializeField]
        private Button buttonMultiply;
        [SerializeField]
        private Button buttonDivide;
        [SerializeField]
        private Button buttonAdd;
        [SerializeField]
        private Button buttonSubtract;
        [SerializeField]
        private Button buttonOpenBracket;
        [SerializeField]
        private Button buttonCloseBracket;
        [SerializeField]
        private Button buttonEquals;
        [SerializeField]
        private Button buttonClear;
        [SerializeField]
        private TMP_InputField inputField;
    
#pragma warning restore 0649

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


        // Start is called before the first frame update
        void Start()
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
