using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace FlashCards
{
    public class AnswerCommand
    {
        private readonly ViewModel _viewModel;

        public AnswerCommand(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Execute()
        {
            if (Process.GetProcessesByName("calc").Length > 0) CheatingDetected();
            else if (_viewModel.CurrentCard.Answer == int.Parse(_viewModel.Answer))
                MarkAnswerCorrect();
            else MarkAnswerIncorrect();
        }

        public void CheatingDetected()
        {
            _viewModel.Status = "Computer malfunction. Tell Seth about this right away!";
            _viewModel.Result = "Computer malfunction. Tell Seth about this right away!";
            _viewModel.Done = true;
            _viewModel.Numerator = "_";
            _viewModel.Denominator = "_";
        }

        private void MarkAnswerIncorrect()
        {
            _viewModel.Answer = String.Empty;
            _viewModel.Result = String.Format("Your answer was WRONG. {0} ÷ {1} = {2}",
                _viewModel.CurrentCard.Numerator,
                _viewModel.CurrentCard.Denominator,
                _viewModel.CurrentCard.Answer);
            NextCard();
        }

        private void MarkAnswerCorrect()
        {
            _viewModel.Answer = String.Empty;
            _viewModel.Result = String.Format("CORRECT!");
            _viewModel.NumberCorrect++;
            NextCard();
        }

        private void NextCard()
        {
            _viewModel.Status = String.Format("{0}/{1} correct",
                _viewModel.NumberCorrect, _viewModel.NumberOfProblems);
            if (_viewModel.AllCards.Count == 0)
            {
                Finished();
                return;
            }
            _viewModel.CurrentCard = _viewModel.AllCards.Dequeue();
            _viewModel.Numerator = _viewModel.CurrentCard.Numerator.ToString();
            _viewModel.Denominator = _viewModel.CurrentCard.Denominator.ToString();
        }

        private void Finished()
        {
            _viewModel.Done = true;
            _viewModel.Numerator = "_";
            _viewModel.Denominator = "_";
            _viewModel.Result = "You are done!";
        }
    }
}
