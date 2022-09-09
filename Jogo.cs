using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura
{
    class Jogo
    {
        public enum resultado { Ganhar, Perder, Empatar }

        public static Image[] imagens =//Carrega todas as imagens que serão utilizadas na variável imagens
        {
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Pedra.png"),
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Papel.png"),
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Tesoura.png"),
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Ganhar.png"),
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Empatar.png"),
                Image.FromFile("C:\\Users\\shaka\\Desktop\\Projetos\\PedraPapelTesoura\\bin\\Debug\\Perder.png")
               
        };

        public Image ImgPC { get;private set; }
        public Image ImgJogador { get;private set; }
        public resultado Jogar(int jogador)
        {
            int pc = JogadaPC();//Recebe a jogada do computador - Pedra = 0 | Papel = 1 | Tesoura = 2

            ImgJogador = imagens[jogador];
            ImgPC = imagens[pc];

            if (jogador == pc)//Se as jogadas forem iguais, será considerado um empate
            {
                return resultado.Empatar;
            }
            else if ((jogador == 0 && pc == 2) || (jogador == 1 && pc == 0) || (jogador == 2 && pc == 1))//Verifica se jogada do jogador de acordo com as regras do jogo, se ele(jogador) vencer, retorna vitória do jogador
            {
                return resultado.Ganhar;
            }
            else//Caso nenhuma das condições anteriores for atingida, retornará derrota do jogador
            {
                return resultado.Perder;
            }      
        }
        private int JogadaPC()
        {
            int mil = DateTime.Now.Millisecond;//Recebe um valor em millisegundos de acordo com o horário do computador do usuário. Com esse valor que será decidida a jogada do computador

            if (mil < 333)
            {
                return 0;
            }
            else if (mil >= 333 && mil <= 666)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
