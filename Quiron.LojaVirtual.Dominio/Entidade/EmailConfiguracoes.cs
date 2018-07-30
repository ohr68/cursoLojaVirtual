namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "teste.co.br";
        public int ServidorPorta = 587;
        public string Usuario = "quiron";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"C:\Users\Otávio\Documents\Visual Studio 2017\Projects\Quiron.LojaVirtual\Email";
        public string De = "quiron@quiron.com.br";
        public string Para = "pedido@quiron.com.br";
    }
}