using System;
using System.Collections.Generic;
using System.Text;
using System.Net; //biblioteca utilizada para download de via http//
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEndercoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEndercoURL);

            //Deserializar (JSON) para deserializar podemos utilizar uma biblioteca
            //que faremos download que se chama NewtonSoft
            //Clicar com o botão direito em cima do projeto 

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if (end.cep == null) return null;

            return end;
            
        }
    }
}
