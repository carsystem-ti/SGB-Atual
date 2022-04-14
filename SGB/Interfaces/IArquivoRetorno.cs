using BoletoBr.Dominio;
using BoletoNet;

namespace BoletoBr.Interfaces
{
    public interface IArquivoRetorno
    {
        IBanco Banco { get; }
        Dominio.TipoArquivo TipoArquivo { get; }
    }
}
