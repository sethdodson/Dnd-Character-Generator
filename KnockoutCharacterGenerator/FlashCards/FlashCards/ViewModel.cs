using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlashCards
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _numerator;
        private string _denominator;
        private string _answer;
        private string _result;
        private string _status;
        private bool _canAnswer;
        private bool _done;

        public string Numerator
        {
            get { return _numerator; }
            set
            {
                _numerator = value;
                RaisePropertyChanged("Numerator");
            }
        }

        public string Denominator
        {
            get { return _denominator; }
            set
            {
                _denominator = value;
                RaisePropertyChanged("Denominator");
            }
        }

        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                RaisePropertyChanged("Answer");
                int result;
                CanAnswer = (int.TryParse(_answer, out result)) && !Done;
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged("Result");
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        public bool CanAnswer
        {
            get { return _canAnswer; }
            set
            {
                _canAnswer = value;
                RaisePropertyChanged("CanAnswer");
            }
        }

        public int NumberOfProblems { get; private set; }
        public int NumberCorrect { get; set; }
        public Queue<Cards.FlashCard> AllCards { get; private set; }
        public Cards.FlashCard CurrentCard { get; set; }
        public AnswerCommand AnswerCommand { get; private set; }

        public bool Done
        {
            get { return _done; }
            set
            {
                _done = value;
                CanAnswer = false;
            }
        }

        public ViewModel()
        {
            AllCards = new Queue<Cards.FlashCard>(Cards.problemCards);
            NumberOfProblems = AllCards.Count;
            CurrentCard = AllCards.Dequeue();
            _status = String.Format("0 out of {0} correct", NumberOfProblems);
            _numerator = CurrentCard.Numerator.ToString();
            _denominator = CurrentCard.Denominator.ToString();
            _result = String.Empty;
            AnswerCommand = new AnswerCommand(this);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler == null) return;
            handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
