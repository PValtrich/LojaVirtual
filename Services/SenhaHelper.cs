using System;
using System.Security.Cryptography;

namespace LojaVirtual.Services
{
    //Transforma a senha em um hash com PBKDF2, para o banco não guardar a senha original
    public static class SenhaHelper
    {
        //Quantidade de repetições do cálculo: quanto maior, mais difícil de adivinhar
        const int Iteracoes = 10000;
        const int TamanhoSal = 16;
        const int TamanhoHash = 32;

        //Retorna "iterações.sal.hash", tudo em Base64, pronto para guardar no banco
        public static string GerarHash(string senha)
        {
            //O sal é aleatório, então a mesma senha gera hashes diferentes
            byte[] sal = new byte[TamanhoSal];
            using (RandomNumberGenerator gerador = RandomNumberGenerator.Create())
                gerador.GetBytes(sal);

            byte[] hash;
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(senha, sal, Iteracoes))
                hash = pbkdf2.GetBytes(TamanhoHash);

            return Iteracoes + "." + Convert.ToBase64String(sal) + "." + Convert.ToBase64String(hash);
        }
    }
}
