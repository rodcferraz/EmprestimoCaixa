using EmprestimoCaixa.Data;
using EmprestimoCaixa.Entities;

namespace EmprestimoCaixa.Dtos.Builder
{
    public class SimulacaoEmprestimoDTOBuilder
    {
        public SimulacaoEmprestimoDTO _simulacaoEmprestimoDTO = new();

        public SimulacaoEmprestimoDTOBuilder SetProduto(Produto produto)
        {
            _simulacaoEmprestimoDTO.Produto = produto;
            return this;
        }

        public SimulacaoEmprestimoDTOBuilder SetEmprestimoSolicitado(PedidoEmprestimoDTO pedidoEmprestimoDTO)
        {
            _simulacaoEmprestimoDTO.ValorSolicitado = pedidoEmprestimoDTO.ValorSolicitado;
            _simulacaoEmprestimoDTO.PrazoMeses = pedidoEmprestimoDTO.PrazoMeses;
            return this;
        }

        public SimulacaoEmprestimoDTOBuilder SetTaxaJurosEfetivaMensal(decimal taxaJurosEfetivaMensal)
        {
            _simulacaoEmprestimoDTO.TaxaJurosEfetivaMensal = taxaJurosEfetivaMensal;
            return this;
        }

        public SimulacaoEmprestimoDTOBuilder SetValoresComJuros(decimal parcelaFixaMensal, int prazoMeses)
        {
            _simulacaoEmprestimoDTO.ValorTotalComJuros = parcelaFixaMensal * prazoMeses;
            _simulacaoEmprestimoDTO.ParcelaMensal = parcelaFixaMensal;
            return this;
        }

        public SimulacaoEmprestimoDTOBuilder SetParcelas(List<MemoriaCalculoDTO> memoriaCalculoDTO)
        {
            _simulacaoEmprestimoDTO.MemoriaCalculo = memoriaCalculoDTO;
            return this;
        }

        public SimulacaoEmprestimoDTO Build()
        {
            return _simulacaoEmprestimoDTO;
        }
    }
}