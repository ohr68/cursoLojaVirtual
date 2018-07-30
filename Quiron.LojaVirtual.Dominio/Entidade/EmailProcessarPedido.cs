using System.Net;
using System.Net.Mail;
using System.Text;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class EmailPedido
    {
        private EmailConfiguracoes _emailConfiguracoes{ get; set; }

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smptClient = new SmtpClient())
            {
                smptClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smptClient.Host = _emailConfiguracoes.ServidorSmtp;
                smptClient.Port = _emailConfiguracoes.ServidorPorta;
                smptClient.UseDefaultCredentials = false;
                smptClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    //Grava conteúdo do e-mail em pasta
                    smptClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smptClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smptClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                    .AppendLine("Novo Pedido: ")
                    .AppendLine("-------------------------")
                    .AppendLine("Itens");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c} )", item.Quantidade, item.Produto.Nome, subtotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("-------------------------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("-------------------------------------")
                    .AppendFormat("Para presente?: {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo pedido", body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smptClient.Send(mailMessage);
            }
        }
    }


}
