using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlashCards
{
    public partial class Form1 : Form
    {
        private readonly ViewModel _viewModel = new ViewModel();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            viewModelBindingSource.DataSource = _viewModel;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            _viewModel.AnswerCommand.Execute();
        }
    }
}
