using System;
using System.Windows.Forms;

namespace PedraPapelTesoura
{
    public partial class Form1 : Form
    {
        public int vitoriasseguidas = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnPedra_Click(object sender, EventArgs e)
        {
            ComecarJogo(0);
        }

        private void btnPapel_Click(object sender, EventArgs e)
        {
            ComecarJogo(1);
        }

        private void btnTesoura_Click(object sender, EventArgs e)
        {
            ComecarJogo(2);
        }

        private void ComecarJogo(int opcao)
        {
            labelResultado.Visible = false;
            Jogo jogar = new Jogo();

            switch (jogar.Jogar(opcao))//Recebe o retorno do método Jogar / 0 = Ganhar / 1 = Perder / 2 = Empatar
            {
                case Jogo.resultado.Ganhar:
                    picResultado.BackgroundImage = Jogo.imagens[3];
                    vitoriasseguidas++;//Em caso de vitória será incrementado uma vitória na variável
                    labelVitorias.Text = "Vitórias Seguidas: " + vitoriasseguidas;//Atualiza o label de vitórias seguidas
                    goto default;
                case Jogo.resultado.Perder:
                    picResultado.BackgroundImage = Jogo.imagens[5];
                    vitoriasseguidas = 0;
                    labelVitorias.Text = "Vitórias Seguidas: " + vitoriasseguidas;
                    goto default;
                case Jogo.resultado.Empatar:
                    picResultado.BackgroundImage = Jogo.imagens[4];
                    vitoriasseguidas = 0;
                    labelVitorias.Text = "Vitórias Seguidas: " + vitoriasseguidas;
                    goto default;
                default:
                    pictureBox1.Image = jogar.ImgJogador;
                    pictureBox2.Image = jogar.ImgPC;
                    break;
            }
        }
    }
}
