using CentralAluno.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CentralAluno.Desktop
{
    public partial class frmIncluirAluno : Form
    {
        public frmIncluirAluno()
        {
            InitializeComponent();
        }

        private void btnIncluirAluno_Click(object sender, EventArgs e)
        {
            ctlAluno _ctlAluno = new ctlAluno();
            bool retorno = _ctlAluno.incluirAluno(txtNome.Text, txtCPF.Text, txtRG.Text);
        }
    }
}
